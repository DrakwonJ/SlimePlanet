using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyQuest : MonoBehaviour
{
    public GameObject progress;
    public List<GameObject> questList = new List<GameObject>();
    public string type;
    public Button btn;
    public GameObject daily;
    public GameObject weekly;
    public GameObject achieve;
    public Button btn1;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Quest);
        btn1.onClick.AddListener(Quest);
        AllQuestList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quest()
    {
        UpdateQuestList();
    }

    public void AllQuestList()
    {
        GameObject instant;
        if (type == "Achieve")
        {
            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[0].GetComponent<UI_QuestList>().questListUp(type, "catchSlime");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[1].GetComponent<UI_QuestList>().questListUp(type, "matingTime");


            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[2].GetComponent<UI_QuestList>().questListUp(type, "bornTime");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[3].GetComponent<UI_QuestList>().questListUp(type, "spendMoney");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[4].GetComponent<UI_QuestList>().questListUp(type, "avgPower");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[5].GetComponent<UI_QuestList>().questListUp(type, "maxPower");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[6].GetComponent<UI_QuestList>().questListUp(type, "sumPower");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[7].GetComponent<UI_QuestList>().questListUp(type, "spendJem");
        }
        else
        {
            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[0].GetComponent<UI_QuestList>().questListUp(type, "catchSlime");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[1].GetComponent<UI_QuestList>().questListUp(type, "catchSlime2");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[2].GetComponent<UI_QuestList>().questListUp(type, "matingTime");


            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[3].GetComponent<UI_QuestList>().questListUp(type, "bornTime");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[4].GetComponent<UI_QuestList>().questListUp(type, "spendMoney");


            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[5].GetComponent<UI_QuestList>().questListUp(type, "earnMoney");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[6].GetComponent<UI_QuestList>().questListUp(type, "watchAd");

            instant = Instantiate(progress); instant.transform.SetParent(gameObject.transform);
            instant.transform.localScale = new Vector3(1, 1, 1); instant.transform.localPosition = new Vector3(0, 0, 0);
            questList.Add(instant); questList[7].GetComponent<UI_QuestList>().questListUp(type, "spendJem");
        }
    }

    public void UpdateQuestList()
    {
        if (type == "Achieve")
        {
            questList[0].GetComponent<UI_QuestList>().questListUp(type, "catchSlime");
            questList[1].GetComponent<UI_QuestList>().questListUp(type, "matingTime");
            questList[2].GetComponent<UI_QuestList>().questListUp(type, "bornTime");
            questList[3].GetComponent<UI_QuestList>().questListUp(type, "spendMoney");
            questList[4].GetComponent<UI_QuestList>().questListUp(type, "avgPower");
            questList[5].GetComponent<UI_QuestList>().questListUp(type, "maxPower");
            questList[6].GetComponent<UI_QuestList>().questListUp(type, "sumPower");
            questList[7].GetComponent<UI_QuestList>().questListUp(type, "spendJem");
        }
        else
        {
            questList[0].GetComponent<UI_QuestList>().questListUp(type, "catchSlime");
            questList[1].GetComponent<UI_QuestList>().questListUp(type, "matingTime");
            questList[2].GetComponent<UI_QuestList>().questListUp(type, "bornTime");
            questList[3].GetComponent<UI_QuestList>().questListUp(type, "spendMoney");
            questList[4].GetComponent<UI_QuestList>().questListUp(type, "earnMoney");
            questList[5].GetComponent<UI_QuestList>().questListUp(type, "catchSlime2");
            questList[6].GetComponent<UI_QuestList>().questListUp(type, "watchAd");
            questList[7].GetComponent<UI_QuestList>().questListUp(type, "spendJem");
        }
    }
}
