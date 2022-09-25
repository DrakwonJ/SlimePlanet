using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class texttest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        BackendReturnObject bro = Backend.BMember.GetUserInfo();
        gameObject.GetComponent<Text>().text = bro.GetReturnValue();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (PlayerInfo._stepCounter == null)
            gameObject.transform.GetComponent<Text>().text = "Cant estimate";
        else
             gameObject.transform.GetComponent<Text>().text = PlayerInfo._stepCounter.stepCounter.ReadValue().ToString();
        */
        //gameObject.GetComponent<Text>().text = "¿À´Ã °ÉÀ½ ¼ö\n" + PlayerInfo.playerInfo._currWalk;
    }
}
