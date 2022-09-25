using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager { get; set; }
    public float bgmVolume = 1.0f;
    public float effectVolume = 1.0f;
    public Camera camera;
    public AudioSource select;
    public AudioSource confirm;
    public AudioSource decline;
    public AudioSource denied;
    public AudioSource Item;
    public AudioSource equip;
    public AudioSource unequip;
    public AudioSource sell;
    public AudioSource create;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (soundManager == null)
            soundManager = this;
        else if (soundManager != this)
            Destroy(gameObject);
    }

    void Start()
    {
        bgmVolume = PlayerPrefs.GetFloat("bgm", 1.0f);
        effectVolume = PlayerPrefs.GetFloat("effect", 1.0f);
        camera.GetComponent<AudioSource>().volume = bgmVolume;
    }

    // Update is called once per frame
    void Update()
    {
        camera.GetComponent<AudioSource>().volume = bgmVolume;
    }

    public void SelectSound()
    {
        select.volume = effectVolume;
        select.Play();
    }

    public void ConfirmSound()
    {
        confirm.volume = effectVolume;
        confirm.Play();
    }

    public void DeniedSound()
    {
        denied.volume = effectVolume;
        denied.Play();
    }

    public void DeclineSound()
    {
        decline.volume = effectVolume;
        decline.Play();
    }

    public void ItemSound()
    {
        Item.volume = effectVolume;
        Item.Play();
    }

    public void EquipSound()
    {
        equip.volume = effectVolume;
        equip.Play();
    }

    public void UnequipSound()
    {
        unequip.volume = effectVolume;
        unequip.Play();
    }

    public void SellSound()
    {
        sell.volume = effectVolume;
        sell.Play();
    }

    public void CreateSound()
    {
        create.volume = effectVolume;
        create.Play();
    }
}
