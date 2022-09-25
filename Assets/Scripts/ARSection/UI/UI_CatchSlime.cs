using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CatchSlime : MonoBehaviour
{
    public static UI_CatchSlime catchSlime;
    private void Awake()
    {
        if (catchSlime == null)
            catchSlime = this;
    }
    public Text txt;
    float time = 3.0f;
    float pastTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;
        txt.text = "Catch Slime! \nGo Back in " + Mathf.RoundToInt(time - pastTime).ToString();
        if (pastTime > time)
            SceneChange.sceneChanege.LoadScene();
    }


    public void CatchSlimeOk()
    {
        this.gameObject.SetActive(true);
    }
}
