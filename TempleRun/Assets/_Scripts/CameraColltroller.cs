using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColltroller : MonoBehaviour
{

    private Transform lookAt;
    public GameObject player;
    private Vector3 offset;
    private Vector3 move;

    private float transition;
    private float animDuration; // Time ani camera
    private Vector3 animOffset;


    void Start()
    {
        animDuration = 2.5f;
        animOffset = new Vector3(0, 4, 4);
        lookAt = player.transform;
        offset = transform.position - lookAt.position;
    }

    void Update()
    {
        move = lookAt.position + offset;

        move.x = 0;

        move.y = Mathf.Clamp(move.y, 3, 5);
        if (transition > 1.0f)
        {
            transform.position = move;
        }
        else
        {
            transform.position = Vector3.Lerp(move + animOffset, move, transition);
            transition += Time.deltaTime * 1 / animDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}
