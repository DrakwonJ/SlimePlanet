using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMailList : MonoBehaviour
{
    public GameObject mailPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ListUpMail();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ListUpMail()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < DataManager.dataManager.postItemList.Count; i++)
        {
            GameObject obj = Instantiate(mailPrefab);
            obj.transform.SetParent(gameObject.transform);
            obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            obj.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            obj.GetComponent<MailContent>().mail = DataManager.dataManager.postItemList[i];
        }
    }
}
