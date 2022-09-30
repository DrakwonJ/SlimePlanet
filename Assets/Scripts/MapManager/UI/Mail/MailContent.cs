using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailContent : MonoBehaviour
{
    public UPostItem mail;
    public Text title;
    public Text jem;
    public Text money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        title.text = mail.title;
        if(mail.rewardType == "jem")
        {
            jem.text = mail.rewardNum.ToString();
            money.text = "0";
        }
        else if (mail.rewardType == "money")
        {
            money.text = mail.rewardNum.ToString();
            jem.text = "0";
        }
    }
}
