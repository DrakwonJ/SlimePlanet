using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EggSelectBtn : MonoBehaviour
{
    Button btn;
    public GameObject window;
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
        if (EggManager.eggManager.targetEgg == null)
            return;
        else
        {
            SoundManager.soundManager.ConfirmSound();
            window.SetActive(false);
            EggManager.eggManager.PlaceEggIncu();
        }
    }
}
