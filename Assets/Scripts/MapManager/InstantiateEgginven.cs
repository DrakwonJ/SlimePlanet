using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEgginven : MonoBehaviour
{
    List<GameObject> _eggInven = new List<GameObject>();
    List<string> _eggCode = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        EggManager.eggManager.eggListOn = true;
        _eggInven = EggManager.eggManager.eggList;
        for(int i = 0; i < _eggInven.Count; i++)
        {
             _eggInven[i].transform.SetParent(gameObject.transform);
            _eggInven[i].transform.localScale = new Vector3(400, 400, 400);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
