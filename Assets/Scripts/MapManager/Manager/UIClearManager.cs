using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIClearManager : MonoBehaviour
{
    public static UIClearManager clearUI { get; set; }
    public List<GameObject> ClickedList;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (clearUI == null)
            clearUI = this;
        else if (clearUI != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearClicked()
    {
        GameObject target;
        for(int i = 0; i < ClickedList.Count; i++)
        {
            if (ClickedList[i].gameObject == null)
                continue;
            target = ClickedList[i].transform.GetChild(4).gameObject;
            Image image = target.GetComponent<Image>();
            Color color = image.GetComponent<Image>().color;
            color.a = 0.0f;
            image.color = color;
        }
        ClickedList.Clear();
        MoneyManager.moneyManager.SellSlimeList.Clear();
        MoneyManager.moneyManager.sellMoney = 0;
        MatingManager.matingManager.targetSlime = null;
    }

}
