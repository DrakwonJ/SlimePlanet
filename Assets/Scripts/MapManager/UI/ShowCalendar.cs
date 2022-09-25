using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShowCalendar : MonoBehaviour
{
    public Text text;
    public ShowCalendarInfo info;
    public Image select;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        if (btn != null)
            return;
        btn = GetComponent<Button>();
    }

    public void Initalize(int _index, UnityEvent<DateTime, string> _event)
    {
        info.orgNumber = _index;
        _event.AddListener(UpdateButtonInfo);
    }

    public void InitComponent()
    {
        if (null != btn)
            return;
        btn = GetComponent<Button>();
    }

    public void OnButtonSelect()
    {

    }

    public int FirstOfMonthDay(DateTime _date)
    {
        DateTime firstOfMonth = new DateTime(_date.Year, _date.Month, 1);
        return (int)firstOfMonth.DayOfWeek + 1;
    }

    public int DaysInMonth(DateTime _date)
    {
        return DateTime.DaysInMonth(_date.Year, _date.Month);
    }

    public void UpdateButtonInfo(DateTime _dateTime, string clearData)
    {
        info.dayNumber = ((info.orgNumber - FirstOfMonthDay(_dateTime) + 1) + 1);
        bool enable = false;
        string currentText = $"{info.dayNumber}";
        Color textColor = Color.black;
        bool include = (((info.dayNumber > 0) && (info.dayNumber < DaysInMonth(_dateTime))));
        DateTime today = DateTime.Now;

        info.dateTime = DateTime.Now;

        if (include)
        {
            info.dateTime = new DateTime(_dateTime.Year, _dateTime.Month, info.dayNumber);
            if(info.dateTime.Year == today.Year && info.dateTime.Month == today.Month && info.dateTime.Day == today.Day)
            {
                info.buttonType = ShowCalendarInfo.ButtonType.Current;
                enable = true;
            }

            else if((DateTime.Compare((DateTime)info.dateTime, today) > 0) == true)
            {
                info.buttonType = ShowCalendarInfo.ButtonType.Disable;
            }

            else if (include)
            {
                if (clearData.Substring((info.dayNumber - 1), 1).Equals("1"))
                    info.buttonType = ShowCalendarInfo.ButtonType.Clear;
                else
                    info.buttonType = ShowCalendarInfo.ButtonType.Enable;
                enable = true;
            }
        }

        else
        {
            info.buttonType = ShowCalendarInfo.ButtonType.NotExist;
            currentText = string.Empty;
        }

        switch (info.buttonType)
        {
            case ShowCalendarInfo.ButtonType.Current: textColor = Color.green; break;
            case ShowCalendarInfo.ButtonType.Clear:textColor = Color.cyan; break;
            default:
                {
                    if (include)
                    {
                        switch (info.dateTime.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:textColor = Color.red;break;
                            case DayOfWeek.Saturday: textColor = Color.blue;break;
                            default:
                                {
                                    
                                }
                                break;
                        }
                        if (info.buttonType == ShowCalendarInfo.ButtonType.Disable)
                            textColor = new Color(textColor.r, textColor.g, textColor.b, 0.5f);
                    }
                    else
                    {
                        textColor = new Color(0, 0, 0, 0);
                    }
                }
                break;
        }
        if(btn == null)
        {
            InitComponent();
            Debug.Log($"[CalendatDayButton]{this.name} :: {info.orgNumber}");
        }

        btn.enabled = enable;
        text.text = currentText;
        text.color = textColor;

        //if (false == info.dateTime.HasValue)
        //    return;
        if (CheckInit(info.dateTime))
            OnButtonSelect();
    }

    private bool CheckInit(DateTime _info)
    {
        DateTime today = DateTime.Now;
        if (today.Year == _info.Year && today.Month == _info.Month)
            return (today.Day == _info.Day);
        else
            return (_info.Day == 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
