using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJgdr : MonoBehaviour
{
    public Transform ZonaSpawnDelDisparoJgdr;
    public GameObject prefabBalaJgdr;

    public float velDesplzBalaJgdr = 20f;
    public float duracionBala = 2.5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject balaJgdr = Instantiate(prefabBalaJgdr, ZonaSpawnDelDisparoJgdr.position, ZonaSpawnDelDisparoJgdr.rotation);
        Rigidbody rbBala = balaJgdr.GetComponent<Rigidbody>();
        rbBala.AddForce(ZonaSpawnDelDisparoJgdr.transform.forward * velDesplzBalaJgdr, ForceMode.Impulse);

        Destroy(balaJgdr, duracionBala);
    }
}
