using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BackBtn : MonoBehaviour
{
    Button btn;
    public bool backOk;
    public Image backImg;
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
        if (backOk)
        {
            SceneChange.sceneChanege.LoadScene();
        }
        else if (!backOk){
            backImg.gameObject.SetActive(false);
        }
    }
}
