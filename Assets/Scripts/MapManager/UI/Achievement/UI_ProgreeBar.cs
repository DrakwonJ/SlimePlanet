using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProgreeBar : MonoBehaviour
{
    public Text progress;
    float ratio;
    public Image bar;
    public Image reward;
    public Text rewardText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetProgressBar(int cur, int limit)
    {
        progress.text = cur + " / " + limit;
        ratio = (float)cur / limit;
        bar.fillAmount = ratio;
        if (cur < limit)
        {
            reward.transform.parent.gameObject.GetComponent<UI_Reward>().isCompleted = false;
        }
        else
        {
            reward.transform.parent.gameObject.GetComponent<UI_Reward>().isCompleted = true;
        }
    }

    public void SetProgressBar(float cur, float limit)
    {
        progress.text = cur + " / " + limit;
        ratio = (float)cur / limit;
        bar.fillAmount = ratio;
        if (cur < limit)
        {
            reward.transform.parent.gameObject.GetComponent<UI_Reward>().isCompleted = false;
        }
        else
        {
            reward.transform.parent.gameObject.GetComponent<UI_Reward>().isCompleted = true;
        }
    }
}
