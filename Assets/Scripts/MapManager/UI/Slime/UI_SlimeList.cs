using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlimeList : MonoBehaviour
{
    Button btn;
    public GameObject list;
    bool listOn = false;
    public GameObject inven;
    public GameObject sellBtn;
    public GameObject matingBtn;
    public Canvas canvas;
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
            list.SetActive(true);
        SoundManager.soundManager.SelectSound();
        RectTransform rect = list.GetComponent<RectTransform>();
        rect.sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
        listOn = true;
        sellBtn.SetActive(true);
        matingBtn.SetActive(false);
        inven.GetComponent<InstaniateSlimeInven>().UpdateSlimeInven();
    }
}
