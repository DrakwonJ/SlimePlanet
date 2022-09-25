using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SlimePowerText : MonoBehaviour
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
        text.text = "Power : " + transform.parent.GetComponent<SlimeInfo>().power.ToString();
    }
}
