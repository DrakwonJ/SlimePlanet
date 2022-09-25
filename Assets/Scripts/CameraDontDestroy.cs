using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDontDestroy : MonoBehaviour
{
    public static CameraDontDestroy camera { get; set; }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (camera == null)
            camera = this;
        else if (camera != null)
            Destroy(gameObject);
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
