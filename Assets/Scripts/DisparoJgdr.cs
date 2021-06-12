using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJgdr : MonoBehaviour
{
    public Transform ZonaSpawnDelDisparoJgdr;
    public GameObject prefabBalaJgdr;
    public GameObject prefabBala2Jgdr;

    public float velDesplzBalaJgdr = 20f;
    public float duracionBala = 2.5f;

    public bool habilitarDisparoSecundario = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }

        if (habilitarDisparoSecundario) 
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Disparar2();
            }

        } 
    }

    void Disparar()
    {
        GameObject balaJgdr = Instantiate(prefabBalaJgdr, ZonaSpawnDelDisparoJgdr.position, ZonaSpawnDelDisparoJgdr.rotation);
        Rigidbody rbBala = balaJgdr.GetComponent<Rigidbody>();
        rbBala.AddForce(ZonaSpawnDelDisparoJgdr.transform.forward * velDesplzBalaJgdr, ForceMode.Impulse);

        Destroy(balaJgdr, duracionBala);
                        
    }    
    
    public void Disparar2()
    {
        GameObject balasJgdrDuplic = Instantiate(prefabBala2Jgdr, ZonaSpawnDelDisparoJgdr.position, ZonaSpawnDelDisparoJgdr.rotation);
        Rigidbody rbBalas = balasJgdrDuplic.GetComponent<Rigidbody>();
        rbBalas.AddForce(ZonaSpawnDelDisparoJgdr.transform.forward * velDesplzBalaJgdr, ForceMode.Impulse);

        Destroy(balasJgdrDuplic, duracionBala);
    }
}
