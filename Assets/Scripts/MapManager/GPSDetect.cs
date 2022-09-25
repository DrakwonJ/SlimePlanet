using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public  class GPSDetect : MonoBehaviour
{
    bool gpsInit = false;
    LocationInfo currentGPSPosition;
    int gps_connect = 0;



    double detailed_num = 1.0;//���� ��ǥ�� float������ �Ҽ��� �ڸ��� ���� �ڼ��� ��µǴ� double�� ���Ͽ� �ڼ��� ���� ���մϴ�.
    public double _latitude;
    public double _longitude;
    public int _refresh;

    // Use this for initialization
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        Input.location.Start(0.5f);
        int wait = 1000; // �⺻ ��

        // Checks if the GPS is enabled by the user (-> Allow location ) 

        if (Input.location.isEnabledByUser)//����ڿ� ���Ͽ� ��ǥ���� ���� �� �� ���� ���
        {
            while (Input.location.status == LocationServiceStatus.Initializing && wait > 0)//�ʱ�ȭ �������̸�
            {
                wait--; // ��ٸ��� �ð��� ����
            }

            //GPS�� ��� ���ð�

            if (Input.location.status != LocationServiceStatus.Failed)//GPS�� �������̶��
            {
                gpsInit = true;
                InvokeRepeating("RetrieveGPSData", 0.5f, 1.0f);//0.0001�ʿ� �����ϰ� 1�ʸ��� �ش� �Լ��� �����մϴ�.
            }
        }

        else//GPS�� ���� ��� (GPS�� ���� ���ų� �ȵ���̵� GPS�� ���� ���� �ʾ��� ���
        {
            Debug.Log("No GPS");
        }
    }

    void RetrieveGPSData()

    {
        currentGPSPosition = Input.location.lastData;//gps�� �����͸� �޽��ϴ�.
        _latitude = (currentGPSPosition.latitude * detailed_num);//���� ���� �޾�,�ؽ�Ʈ�� ����մϴ�
        _longitude = (currentGPSPosition.longitude * detailed_num);//�浵 ���� �޾�, �ؽ�Ʈ�� ����մϴ�.
        gps_connect++;
        _refresh = gps_connect;
    }
}
