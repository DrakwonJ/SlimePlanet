using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour
{
    public static DragController dragCon { get; set; }
    Vector2 clickPoint;
    public GameObject SlimeList;
    float dragSpeed = 10.0f;
    LayoutGroup3D layout;
    int layoutCount;
    [SerializeField]
    float downLimit = 0;
    [SerializeField]
    float upLimit = 0;

    public bool OnDrag = false;
    public bool isSell = false;
    public bool instaniateOver = true;
    public bool eggList = false;    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (downLimit == 1500 && upLimit == 1500)
            instaniateOver = true;
        if (instaniateOver)
        {
            SetDragLimit();
            if (eggList)
            {
                SetDragLimit(EggManager.eggManager.eggList.Count);
                SlimeList.transform.localPosition += new Vector3(50, 0, 0);
            }
            instaniateOver = false;
        }
        else {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    OnDrag = true;
                    clickPoint = Input.mousePosition;
                }
            }
            if (Input.GetMouseButton(0) && OnDrag == true)
            {
                Vector3 position = new Vector3();
                position = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

                position.x = .0f;
                position.z = .0f;

                Vector3 move = position * (Time.deltaTime * dragSpeed);

                float z = SlimeList.transform.position.z;
                float x = SlimeList.transform.position.x;
                if (SlimeList.transform.localPosition.y + move.y < downLimit)
                {
                    SlimeList.transform.localPosition = new Vector3(SlimeList.transform.localPosition.x, downLimit, SlimeList.transform.localPosition.z);
                    return;
                }
                if (SlimeList.transform.localPosition.y + move.y > upLimit)
                {
                    SlimeList.transform.localPosition = new Vector3(SlimeList.transform.localPosition.x, upLimit, SlimeList.transform.localPosition.z);
                    return;
                }

                SlimeList.transform.Translate(-move);
                SlimeList.transform.position
                        = new Vector3(x, SlimeList.transform.position.y, z);
            }
            if (Input.GetMouseButtonUp(0) && OnDrag == true)
                OnDrag = false;
        }
    }

    public void SetDragLimit()
    {
        layout = SlimeList.GetComponent<LayoutGroup3D>();
        if (eggList)
        {
            if (layout.LayoutElements.Count % 2 == 0)
                downLimit =900 + -600 * ((layout.LayoutElements.Count / 2) - 1);
            else if (layout.LayoutElements.Count % 2 == 1)
                downLimit = 900 + -600 * (layout.LayoutElements.Count / 2);
            if (layout.LayoutElements.Count <= 8)
                upLimit = downLimit;
            else if (layout.LayoutElements.Count > 8)
            {
                upLimit = downLimit + (((layout.LayoutElements.Count - 8) / 2) + ((layout.LayoutElements.Count - 8) % 2)) * 600;
            }
            SlimeList.transform.localPosition = new Vector3(0, downLimit, -1);
        }
        else
        {
            if (layout.LayoutElements.Count % 2 == 0)
                downLimit = 900 + -700 * ((layout.LayoutElements.Count / 2) - 1);
            else if (layout.LayoutElements.Count % 2 == 1)
                downLimit = 900 + -700 * (layout.LayoutElements.Count / 2);
            if (layout.LayoutElements.Count <= 6)
                upLimit = downLimit;
            else if (layout.LayoutElements.Count > 6)
            {
                upLimit = downLimit + (((layout.LayoutElements.Count - 6) / 2) + ((layout.LayoutElements.Count - 6) % 2)) * 700;
            }
        }
        SlimeList.transform.localPosition = new Vector3(0, downLimit, -1);


    }

    public void SetDragLimit(int idx)
    {
        if (eggList)
        {
            if (idx % 2 == 0)
                downLimit = 900 + -600 * ((idx / 2) - 1);
            else if (idx % 2 == 1)
                downLimit = 900 + -600 * (idx / 2);
            if (idx <= 8)
                upLimit = downLimit;
            else if (idx > 8)
            {
                upLimit = downLimit + (((idx - 8) / 2) + ((idx - 8) % 2)) * 600;
            }
            SlimeList.transform.localPosition = new Vector3(0, downLimit, -1);
        }
        else
        {
            if (idx % 2 == 0)
                downLimit = 900 + -700 * ((idx / 2) - 1);
            else if (idx % 2 == 1)
                downLimit = 900 + -700 * (idx / 2);
            if (idx <= 6)
                upLimit = downLimit;
            else if (idx > 6)
            {
                upLimit = downLimit + (((idx - 6) / 2) + ((idx - 6) % 2)) * 700;
            }
        }
        SlimeList.transform.localPosition = new Vector3(0, downLimit, -1);


    }

}
