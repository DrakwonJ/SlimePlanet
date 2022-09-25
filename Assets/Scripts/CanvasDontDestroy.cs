using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasDontDestroy : MonoBehaviour
{
    public static CanvasDontDestroy canvas { get; set; }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (canvas == null)
            canvas = this;
        else if (canvas != null)
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
