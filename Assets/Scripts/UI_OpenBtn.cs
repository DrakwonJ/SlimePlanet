using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpenBtn : MonoBehaviour
{
    public Button btn;
    public GameObject window;
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
        window.SetActive(true);
        SoundManager.soundManager.SelectSound();
    }
}
