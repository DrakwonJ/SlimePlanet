using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EggIncubator : MonoBehaviour
{
    public Button btn;
    public GameObject eggList;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SoundManager.soundManager.SelectSound();
        eggList.SetActive(true);
        RectTransform rect = eggList.GetComponent<RectTransform>();
        rect.sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
    }
}
