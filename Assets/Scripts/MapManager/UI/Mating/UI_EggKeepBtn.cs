using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EggKeepBtn : MonoBehaviour
{
    Button btn;
    public GameObject matingWindow;
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
        Destroy(MatingManager.matingManager.targetSlot1.transform.GetChild(0).gameObject);
        Destroy(MatingManager.matingManager.targetSlot2.transform.GetChild(0).gameObject);
        matingWindow.SetActive(false);
    }
}
