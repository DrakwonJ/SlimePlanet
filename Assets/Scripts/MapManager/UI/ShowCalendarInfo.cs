using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCalendarInfo : MonoBehaviour
{
    public int orgNumber;
    public int dayNumber;
    public DateTime dateTime;
    public ButtonType buttonType;
    public enum ButtonType
    {
        Current,
        Disable,
        Clear,
        Enable,
        NotExist
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
