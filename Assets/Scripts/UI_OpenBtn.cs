using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpenBtn : MonoBehaviour
{
    public Button btn;
    public GameObject window;
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
        if (canvas != null)
        {
            RectTransform rect = window.GetComponent<RectTransform>();
            rect.sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
        }
        window.SetActive(true);
        SoundManager.soundManager.SelectSound();
    }
}
