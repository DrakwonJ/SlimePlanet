using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PowerWindowOpen : MonoBehaviour
{
    Button btn;
    public Canvas canvas;
    public GameObject window;

    // Start is called before the first frame update
    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SoundManager.soundManager.SelectSound();
        window.SetActive(true);
        RectTransform rect = window.GetComponent<RectTransform>();
        rect.sizeDelta = canvas.GetComponent<RectTransform>().rect.size;
    }
}
