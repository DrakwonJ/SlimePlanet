using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectMatingBtn : MonoBehaviour
{
    Button btn;
    public GameObject listWindow;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (MatingManager.matingManager.targetSlime == null)
            return;
        MatingManager.matingManager.SlimeMatingSelect();
        listWindow.SetActive(false);
        MatingManager.matingManager.matingState = false;
        MatingManager.matingManager.targetSlime.transform.GetChild(4).GetComponent<SelectSlimeBtn>().clicked = false;   
        MatingManager.matingManager.targetSlime = null;
    }
}
