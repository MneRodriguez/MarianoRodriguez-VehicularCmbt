using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCam : MonoBehaviour
{
    public GameObject CañoñDelPlayer;
    public Vector3 offset;
    public float movtoCam = 0.5f;
    void Start()
    {
        offset = transform.position + CañoñDelPlayer.transform.position;
    }

    
    void Update()
    {
        Vector3 posDeCam = new Vector3(CañoñDelPlayer.transform.position.x, CañoñDelPlayer.transform.position.y +0.250f, CañoñDelPlayer.transform.position.z -0.78f);

        transform.position = Vector3.SmoothDamp(transform.position, posDeCam, ref offset, movtoCam);
    }
}
