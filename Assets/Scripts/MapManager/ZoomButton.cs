using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomButton : MonoBehaviour
{
    Button btn;
    public bool up;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        int zoom = GameObject.Find("MapImage").GetComponent<GoogleMap>()._zoom;
        if (up && zoom < 22)
        {
            GameObject.Find("MapImage").GetComponent<GoogleMap>()._zoom++;
        }
        else if(!up && zoom > 1)
        {
            GameObject.Find("MapImage").GetComponent<GoogleMap>()._zoom--;
        }
    }
}
