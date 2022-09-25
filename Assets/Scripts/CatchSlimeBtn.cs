using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchSlimeBtn : MonoBehaviour
{
    public Button btn;
    public bool catchOk;
    public Image catchImg;
    public Image fullImg;
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
        if (catchOk) {
            if (DataManager.dataManager.slimeBag == DataManager.dataManager.slimeCode.Count)
            {
                fullImg.GetComponent<UI_MaingErrorMessage>().FullMessage();
                SoundManager.soundManager.DeniedSound();
            }
            else
            {
                catchImg.gameObject.SetActive(false);
                SoundManager.soundManager.ConfirmSound();
                SceneChange.sceneChanege.LoadScene();
            }
        }
        else
        {
            catchImg.gameObject.SetActive(false);
            SoundManager.soundManager.DeclineSound();
        }

    }
}
