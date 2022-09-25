using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSlimeBtn : MonoBehaviour
{

    Button btn;
    public bool clicked = false;
    public bool matingMode = false;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        
        Image img = this.GetComponent<Image>();
        Color color = img.GetComponent<Image>().color;
        if (MatingManager.matingManager != null && MatingManager.matingManager.matingState ==true)
        {
            if (color.a == 0.5f)
            {
                SoundManager.soundManager.UnequipSound();
                color.a = 0.0f;
                //clicked = false;
                MatingManager.matingManager.targetSlime = null;
            }
            else
            {
                if (MatingManager.matingManager.targetSlime != null)
                {
                    GameObject prevSlime = MatingManager.matingManager.targetSlime.transform.GetChild(4).gameObject;
                    prevSlime.GetComponent<SelectSlimeBtn>().OnClick();
                }
                SoundManager.soundManager.EquipSound();
                img = this.GetComponent<Image>();
                color = img.GetComponent<Image>().color;
                color.a = 0.5f;
                //clicked = true;
                MatingManager.matingManager.targetSlime = transform.parent.gameObject;
                UIClearManager.clearUI.ClickedList.Add(transform.parent.gameObject);
            }
        }
        else
        {
            if (color.a == 0.5f)
            {
                SoundManager.soundManager.UnequipSound();
                color.a = 0.0f;
                MoneyManager.moneyManager.SubtractSellSlime(transform.parent.gameObject);
                //clicked = false;
            }
            else
            {
                SoundManager.soundManager.EquipSound();
                color.a = 0.5f;
                MoneyManager.moneyManager.AddSellSlime(transform.parent.gameObject);
                //clicked = true;
                UIClearManager.clearUI.ClickedList.Add(transform.parent.gameObject);
            }
        }
        img.color = color;
    }
}
