using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_IncubatorAdd : MonoBehaviour
{
    public Button btn;
    public GameObject addWindow;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
        if (EggManager.eggManager.incubator >= 12)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (EggManager.eggManager.incubator >= 12)
            gameObject.SetActive(false);
    }

    void OnClick()
    {
        SoundManager.soundManager.SelectSound();
        addWindow.SetActive(true);
    }

}
