using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MatingBtn : MonoBehaviour
{
    public Button btn;
    public GameObject obj;
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
        obj.SetActive(true);
        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
    }
}
