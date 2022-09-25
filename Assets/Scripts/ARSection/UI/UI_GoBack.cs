using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GoBack : MonoBehaviour
{
    Button backButton;
    public Image backImg;
    public Image catchImg;
    public CreateMonster spawningPool;
    // Start is called before the first frame update
    void Start()
    {
        backButton = GetComponent<Button>();
        backButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    { if (!catchImg.gameObject.activeSelf) {
            if (spawningPool.spawnMon.GetComponent<SlimeInfo>().currentHp <= 0)
                catchImg.gameObject.SetActive(true);
        }

    }

    public void OnClick()
    {
        backImg.gameObject.SetActive(true);
    }
}
