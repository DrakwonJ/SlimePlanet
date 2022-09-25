using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SoundSetting : MonoBehaviour
{
    public Slider effectSlider;
    public Slider bgmSlider;
    public Text effectText;
    public Text bgmText;
    // Start is called before the first frame update
    void Start()
    {
        effectSlider.value = SoundManager.soundManager.effectVolume;
        bgmSlider.value = SoundManager.soundManager.bgmVolume;
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerPrefs.GetFloat("bgm") != bgmSlider.value)
        {
            PlayerPrefs.SetFloat("bgm", bgmSlider.value);
            SoundManager.soundManager.bgmVolume = bgmSlider.value;
        }

        if (PlayerPrefs.GetFloat("effect") != effectSlider.value)
        {
            PlayerPrefs.SetFloat("effect", effectSlider.value);
            SoundManager.soundManager.effectVolume = effectSlider.value;
        }

        effectText.text = Mathf.Round(effectSlider.value * 100).ToString();
        bgmText.text = Mathf.Round(bgmSlider.value * 100).ToString();
    }
}
