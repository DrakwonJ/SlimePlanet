using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortByOrder : MonoBehaviour
{
    public Button recentBtn;
    public Button lateBtn;
    public Button powerUpBtn;
    public Button powerDownBtn;
    public GameObject layout;

    // Start is called before the first frame update
    void Start()
    {
        recentBtn.onClick.AddListener(OrderByRecent);
        lateBtn.onClick.AddListener(OrderByLate);
        powerUpBtn.onClick.AddListener(OrderByPowerUp);
        powerDownBtn.onClick.AddListener(OrderByPowerDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OrderByRecent()
    {
        recentBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = true;
        lateBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        powerUpBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        powerDownBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        layout.GetComponent<SortSlimeOrder>().RecentSort();
    }

    void OrderByLate()
    {
        recentBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        lateBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = true;
        powerUpBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        powerDownBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        layout.GetComponent<SortSlimeOrder>().LateSort();
    }

    void OrderByPowerUp()
    {
        recentBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        lateBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        powerUpBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = true;
        powerDownBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        layout.GetComponent<SortSlimeOrder>().PowerUpSort();
    }

    void OrderByPowerDown()
    {
        recentBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        lateBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        powerUpBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        powerDownBtn.transform.GetChild(1).GetComponent<Toggle>().isOn = true;
        layout.GetComponent<SortSlimeOrder>().PowerDownSort();
    }
}
