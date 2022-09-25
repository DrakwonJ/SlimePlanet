using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MatingError : MonoBehaviour
{
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FullEggList()
    {
        txt.text = "알 보관함이 가득 찼습니다";
    }

    public void SameSlimeChoose()
    {
        txt.text = "같은 슬라임을 선택할 수 없습니다";
    }
}
