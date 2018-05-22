using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{


    public Transform playerTransform;

    private float spawnZ = 140f;
    private float mapLength = 70f;
    private float safe = 55f;
    private int numberMapOnScreen = 5;

    public List<GameObject> lstMapPrefabs;

    private GameObject currentMapPrefab;
    private GameObject previeusMapPrefab;
    private
    void Start()
    {
        currentMapPrefab = lstMapPrefabs[1];
        previeusMapPrefab = lstMapPrefabs[0];
        index = 2;
    }
    void Update()
    {
        if (playerTransform.position.z + safe > (spawnZ))
        {
            ActiveMap();
        }
    }
    int index;
    private void ActiveMap()
    {
        if(index == 4)
        {
            GameObject go = lstMapPrefabs[index].gameObject;
            go.transform.position = Vector3.forward * spawnZ;
            go.SetActive(true);
            previeusMapPrefab.SetActive(false);
            previeusMapPrefab = currentMapPrefab;
            currentMapPrefab = go;
            spawnZ += mapLength;
            index = 0;
        }
        else
        {
            GameObject go = lstMapPrefabs[index].gameObject;
            go.transform.position = Vector3.forward * spawnZ;
            go.SetActive(true);
            previeusMapPrefab.SetActive(false);
            previeusMapPrefab = currentMapPrefab;
            currentMapPrefab = go;
            spawnZ += mapLength;
            index++;
        }
        
        




    }

}
