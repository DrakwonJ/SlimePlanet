using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SortSlimeOrder : MonoBehaviour
{
    public List<Transform> slimeList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecentSort()
    {
        slimeList = transform.GetComponent<LayoutGroup3D>().LayoutElements;
        var slimeDict = new Dictionary<Transform, int>();
        for (int i = 0; i < slimeList.Count; i++)
        {
            slimeDict.Add(slimeList[i], (int)slimeList[i].GetComponent<SlimeInfo>().spawnDate);
        }
        slimeDict = slimeDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        slimeList = slimeDict.Keys.ToList();
        for (int i = 0; i < slimeList.Count; i++)
        {
            slimeList[i].SetSiblingIndex(i);
        }
    }

    public void LateSort()
    {
        slimeList = transform.GetComponent<LayoutGroup3D>().LayoutElements;
        var slimeDict = new Dictionary<Transform, int>();
        for (int i = 0; i < slimeList.Count; i++)
        {
            slimeDict.Add(slimeList[i], (int)slimeList[i].GetComponent<SlimeInfo>().spawnDate);
        }
        slimeDict = slimeDict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        slimeList = slimeDict.Keys.ToList();
        for (int i = 0; i < slimeList.Count; i++)
        {
            slimeList[i].SetSiblingIndex(i);
        }
    }

    public void PowerUpSort()
    {
        slimeList = transform.GetComponent<LayoutGroup3D>().LayoutElements;
        var slimeDict = new Dictionary<Transform, int>();
        for (int i = 0; i < slimeList.Count; i++)
        {
            slimeDict.Add(slimeList[i], slimeList[i].GetComponent<SlimeInfo>().power);
        }
        slimeDict = slimeDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        slimeList = slimeDict.Keys.ToList();
        for(int i = 0; i < slimeList.Count; i++)
        {
            slimeList[i].SetSiblingIndex(i);
        }
    }
    public void PowerDownSort()
    {
        slimeList = transform.GetComponent<LayoutGroup3D>().LayoutElements;
        var slimeDict = new Dictionary<Transform, int>();
        for (int i = 0; i < slimeList.Count; i++)
        {
            slimeDict.Add(slimeList[i], slimeList[i].GetComponent<SlimeInfo>().power);
        }
        slimeDict = slimeDict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        slimeList = slimeDict.Keys.ToList();
        for (int i = 0; i < slimeList.Count; i++)
        {
            slimeList[i].SetSiblingIndex(i);
        }
    }
}
