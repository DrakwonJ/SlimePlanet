using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_EggInfoTxt : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "잠재력 : " + transform.parent.GetComponent<EggInfo>().potential.ToString() +
            "\n부화시간 : " + (transform.parent.GetComponent<EggInfo>().bornTime / 60).ToString() + "H";
    }
}
