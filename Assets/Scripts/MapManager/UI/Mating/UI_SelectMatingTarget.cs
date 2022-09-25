using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectMatingTarget : MonoBehaviour
{
    public Button btn;
    public GameObject slimeList;
    public GameObject sellBtn;
    public GameObject matingBtn;
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
        if (gameObject.transform.childCount > 0)
            Destroy(gameObject.transform.GetChild(0).gameObject);
        slimeList.SetActive(true);
        slimeList.transform.GetChild(0).gameObject.GetComponent<InstaniateSlimeInven>().UpdateSlimeInven();
        RectTransform rect = slimeList.GetComponent<RectTransform>();
        rect.sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
        sellBtn.SetActive(false);
        matingBtn.SetActive(true);
        Debug.Log(gameObject.name);
        MatingManager.matingManager.target = this.gameObject;
        MatingManager.matingManager.matingState = true;
    }
}
