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
        text.text = "����� : " + transform.parent.GetComponent<EggInfo>().potential.ToString() +
            "\n��ȭ�ð� : " + (transform.parent.GetComponent<EggInfo>().bornTime / 60).ToString() + "H";
    }
}
