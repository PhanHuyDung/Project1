using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public GameObject objUseFull;
    public GameObject objHarmFull;

    private int childObjUseFull;
    private int childObjHarmFull;
    void Awake()
    {
        childObjUseFull = objUseFull.transform.childCount;
        childObjHarmFull = objHarmFull.transform.childCount;
    }

    public void OnEnable()
    {
        objUseFull.transform.GetChild(Random.Range(0, childObjUseFull)).gameObject.SetActive(true);
        objHarmFull.transform.GetChild(Random.Range(0, childObjUseFull)).gameObject.SetActive(true);
    }


    public void OnDisable()
    {
        for (int i = 0; i < childObjUseFull; i++)
        {
            objUseFull.transform.GetChild(i).gameObject.SetActive(false);
            objHarmFull.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
