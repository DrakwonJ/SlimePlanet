using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortByOrderEgg : MonoBehaviour
{
    public Button potenUpBtn, potenDownBtn;
    public GameObject layout;
    // Start is called before the first frame update
    void Start()
    {
        potenUpBtn.onClick.AddListener(OrderByPotenUp);
        potenDownBtn.onClick.AddListener(OrderByPotenDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OrderByPotenUp()
    {
        potenUpBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = true;
        potenDownBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        layout.GetComponent<SortEggOrder>().PotenDownSort();
        
    }

    public void OrderByPotenDown()
    {
        potenUpBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        potenDownBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = true;
        layout.GetComponent<SortEggOrder>().PotenUpSort();
    }
}
