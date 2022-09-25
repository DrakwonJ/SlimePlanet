using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleMap : MonoBehaviour
{
    // Google Maps API
    // https://developers.google.com/maps/documentation/static-maps/intro  
    public RawImage kRawImg;

    public enum mapType
    {
        roadmap,
        satelite,
        hybrid,
        terrain
    }

    public string strBaseURL = "https://maps.googleapis.com/maps/api/staticmap?center=";
    public double _lat = 37.4014171;      // ����(�Ǳ�)
    public double _lon = 127.1102274;    // �浵(�Ǳ�)
    public int _zoom = 15;
    public int mapWidth = 640;                // ���� ���� �ִ� �ػ�
    public int mapHeight = 640;               // ���� ���� �ִ� �ػ�
    public int _scale = 1;
    public mapType _mapType = mapType.roadmap;
    public string _key = "AIzaSyC5t2LMpVSTYkParYeLU1uFR7q5ErOig3I";       // ������ �߱� ���� API Ű �Է�(��� ��)

    public float screen_width;
    public float screen_height;
    public float map_scale = 1;

    public void map()
    {
        _lat = GetComponent<GPSDetect>()._latitude;
        _lon = GetComponent<GPSDetect>()._longitude;
        string url =
        "https://maps.googleapis.com/maps/api/staticmap?" +
        "center=" + _lat + "," + _lon +
        "&zoom=" + _zoom +
        "&size=" + mapWidth + "x" + mapHeight +
        "&scale=" + map_scale +
        "&maptype=" + _mapType +
        "&markers=color:blue%7Clabel:S%7C" + _lat + "," + _lon +
        "&key=" + _key;
        //Debug.Log("URL: " + url);
        WWW www = new WWW(url);
        while (www.isDone == false)
            new WaitForSeconds(0.1f);
        kRawImg.texture = www.texture;
        kRawImg.SetNativeSize();
        kRawImg.transform.localScale = new Vector3(map_scale, map_scale);
    }
    private void Awake()
    {
        screen_height = Screen.height;
        screen_width = Screen.width;
        map_scale =  screen_width / 640;
    }
    // Use this for initialization
    void Start()
    {
        kRawImg = gameObject.GetComponent<RawImage>();
        InvokeRepeating("map", 0.1f, 1);
    }

    // Update is called once per frame

    void Update()
    {

    }



}
