using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCam : MonoBehaviour
{
    public GameObject CañoñDelPlayer;
    public Vector3 offset;
    public float movtoCam = 0.5f;

    public Transform cañonJgdrParaGiroCam;
    public float velGiroDeCam = 0.8f;
    void Start()
    {
        offset = transform.position + CañoñDelPlayer.transform.position;
    }

    
    void Update()
    {
        Vector3 posDeCam = new Vector3(CañoñDelPlayer.transform.position.x, CañoñDelPlayer.transform.position.y +0.250f, CañoñDelPlayer.transform.position.z -0.78f);

        transform.position = Vector3.SmoothDamp(transform.position, posDeCam, ref offset, movtoCam);
    }

    private void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * velGiroDeCam, Vector3.up) * offset;
        //transform.position = cañonJgdrParaGiroCam.position + offset;
        transform.LookAt(cañonJgdrParaGiroCam, Vector3.up);
    }
}
