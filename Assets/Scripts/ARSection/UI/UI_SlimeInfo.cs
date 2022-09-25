using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlimeInfo : MonoBehaviour
{
    public Button btn;
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickButton()
    {
        if (img.IsActive() == false)
            img.gameObject.SetActive(true);
        else if (img.IsActive() == true)
            img.gameObject.SetActive(false);
    }
}
