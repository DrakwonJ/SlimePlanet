using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortEggOrder : MonoBehaviour
{
    List<Transform> eggList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PotenUpSort()
    {
        eggList = transform.GetComponent<LayoutGroup3D>().LayoutElements;
        var eggDict = new Dictionary<Transform, int>();
        for(int i=0; i <eggList.Count; i++)
        {
            eggDict.Add(eggList[i], eggList[i].GetComponent<EggInfo>().potential);
        }
        eggDict = eggDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        eggList = eggDict.Keys.ToList();
        for (int i = 0; i < eggList.Count; i++)
            eggList[i].SetSiblingIndex(i);
    }

    public void PotenDownSort()
    {
        eggList = transform.GetComponent<LayoutGroup3D>().LayoutElements;
        var eggDict = new Dictionary<Transform, int>();
        for (int i = 0; i < eggList.Count; i++)
        {
            eggDict.Add(eggList[i], eggList[i].GetComponent<EggInfo>().potential);
        }
        eggDict = eggDict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        eggList = eggDict.Keys.ToList();
        for (int i = 0; i < eggList.Count; i++)
            eggList[i].SetSiblingIndex(i);
    }
}
