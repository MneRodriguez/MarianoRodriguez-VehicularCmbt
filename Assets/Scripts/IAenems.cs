﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAenems : MonoBehaviour
{
    public Transform puntoDeDestino;
    Rigidbody rb;
    public float speed = 10.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.AddForce(CalcularVector(), ForceMode.Force);
    }

    private Vector3 CalcularVector()
    {
        Vector3 VectorDeDistancia = (puntoDeDestino.position - transform.position);
        float distancia = VectorDeDistancia.magnitude;
        speed = Mathf.Lerp(distancia, 0, Time.deltaTime);
        return Vector3.Normalize(VectorDeDistancia) * speed;
    }
}
