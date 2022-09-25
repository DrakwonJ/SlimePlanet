using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange sceneChanege;

    public void Awake()
    {
        if (sceneChanege == null)
            sceneChanege = this;
        else if (sceneChanege != this)
            Destroy(gameObject);
    }
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene()
    {
        StartCoroutine(LoadAsyncScene());
    }
    public IEnumerator LoadAsyncScene()
    {
        int curIndex = 0;
        int nextIndex = 0;
        curIndex = SceneManager.GetActiveScene().buildIndex;
        if (curIndex == 0)
        {
            nextIndex = 1;
            CanvasDontDestroy.canvas.gameObject.SetActive(false);
        }
        else if (curIndex == 1)
        {
            nextIndex = 0;
            CanvasDontDestroy.canvas.gameObject.SetActive(true);
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextIndex);
        while (!asyncLoad.isDone)
            yield return null;
    }
}
