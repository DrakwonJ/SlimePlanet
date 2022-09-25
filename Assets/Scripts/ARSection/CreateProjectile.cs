using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class CreateProjectile : MonoBehaviour
{
    Button btn;
    public Image image;
    public GameObject projectileSpawn;
    public Camera arCamera;
    public bool isClicked = false;
    float leftTime = 1.0f;
    public float coolTime = DataManager.dataManager.attackRate;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickButton);
        leftTime = coolTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            if(leftTime > 0)
            {
                leftTime -= Time.deltaTime * 1.0f;
                if(leftTime < 0)
                {
                    leftTime = 0;
                    if (btn)
                        btn.enabled = true;
                    isClicked = true;
                }

                float ratio = 1.0f - (leftTime / coolTime);
                if (image)
                    image.fillAmount = ratio;
            }
        }
    }

    void OnClickButton()
    {
        leftTime = coolTime;
        isClicked = true;
        GameObject projectile = Instantiate(projectileSpawn);
        projectile.transform.position = arCamera.GetComponent<ARCameraManager>().transform.position;
        if (btn)
            btn.enabled = false;    
    }
}
