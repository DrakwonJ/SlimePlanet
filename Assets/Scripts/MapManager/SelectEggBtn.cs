using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEggBtn : MonoBehaviour
{
    Button btn;
    public bool clicked = false;
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
        Image img = GetComponent<Image>();
        Color color = img.GetComponent<Image>().color;
        if(clicked)
        {
            SoundManager.soundManager.UnequipSound();
            color.a = 0.0f;
            EggManager.eggManager.targetEgg = null;
            clicked = false;
        }
        else
        {
            SoundManager.soundManager.EquipSound();
            if(EggManager.eggManager.targetEgg != null)
            {
                GameObject prevEgg = EggManager.eggManager.targetEgg.transform.GetChild(4).gameObject;
                prevEgg.GetComponent<SelectEggBtn>().OnClick();
                UIClearManager.clearUI.ClickedList.Remove(prevEgg);
            }
            color.a = 0.5f;
            EggManager.eggManager.targetEgg = transform.parent.gameObject;
            clicked = true;
            UIClearManager.clearUI.ClickedList.Add(transform.parent.gameObject);
        }
        img.color = color;
    }
}
