using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CreateMonster : MonoBehaviour
{

    public GameObject targetMon;
    public GameObject spawnMon;
    public Camera arCamera;
    public ARRaycastManager raycastManager;
    public ParticleSystem spawnCloud;
    public ParticleSystem spawnParticle;
    private bool isSpawn = false;
    public int slimeNum;


    public float colorCoder = 0;
    public float colorCodeg = 0;
    public float colorCodeb = 0;
    public GameObject[] slimePool;
    // Start is called before the first frame update
    void Awake()
    {
        colorCoder = Random.Range(0.0f, 1.0f);
        colorCodeg = Random.Range(0.0f, 1.0f);
        colorCodeb = Random.Range(0.0f, 1.0f);
        colorCoder = parsedot2(colorCoder);
        colorCodeg = parsedot2(colorCodeg);
        colorCodeb = parsedot2(colorCodeb);

        slimeNum = Random.Range(0, 9);
        targetMon = slimePool[slimeNum];
        spawnMon = Instantiate(targetMon, new Vector3(100,100,100), targetMon.transform.rotation);
        spawnMon.GetComponent<SlimeInfo>().Ui_on = false;
        spawnMon.GetComponent<SlimeInfo>().UI_ON();
        GameObject childObj = spawnMon.transform.GetChild(1).gameObject;
        Material slimeMat = childObj.GetComponent<SkinnedMeshRenderer>().materials[0];
        Color slimeColor = slimeMat.color;
        slimeColor.r = colorCoder;
        slimeColor.g = colorCodeg;
        slimeColor.b = colorCodeb;
        childObj.GetComponent<SkinnedMeshRenderer>().materials[0].color = slimeColor;

        if(SceneManager.GetActiveScene().name == "ARScene")
            spawnParticle = Instantiate(spawnCloud, spawnMon.transform.position, transform.rotation) as ParticleSystem;

    }

    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnMon == null)
            return;
        CreateMon();
        if (spawnMon.GetComponent<SlimeInfo>().currentHp == 0)
        {
            spawnParticle.transform.position = spawnMon.transform.position;
            spawnParticle.Play(true);
        }
    }

    float parsedot2(float val)
    {
        var str = val.ToString("0.00");
        return float.Parse(str);
    }

    void CreateMon()
    {
        if (isSpawn)
            return;
        Vector3 targetPos = new Vector3(arCamera.pixelWidth / 2, arCamera.pixelHeight * 3 / 4);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        Ray ray = arCamera.ScreenPointToRay(targetPos);
        if (raycastManager.Raycast(targetPos, hits, TrackableType.Planes))
        {
            Pose pose = hits[0].pose;
            spawnMon.SetActive(true);
            spawnMon.transform.position = pose.position;
            LookCamera();
            spawnParticle.transform.position = spawnMon.transform.position;
            spawnParticle.Play(true);
            spawnParticle.Play(true);
            isSpawn = true;
        }
    }

    void LookCamera()
    {
        Vector3 v = arCamera.GetComponent<ARCameraManager>().transform.position - spawnMon.transform.position;
        v.x = v.z = 0;
        spawnMon.transform.LookAt(arCamera.GetComponent<ARCameraManager>().transform.position - v);
    }
}
