using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IAenems : MonoBehaviour
{
    public GameObject Enem;
    public Rigidbody rbEnem;

    /*public Transform puntoDeDestino;
    Rigidbody rb;
    public float speed = 10.5f;*/
    void Start()
    {
        rbEnem = GetComponent<Rigidbody>();

    }

    
    void Update()
    {
        //rb.AddForce(CalcularVector(), ForceMode.Force);
    }

    /*private Vector3 CalcularVector()
    {
        Vector3 VectorDeDistancia = (puntoDeDestino.position - transform.position);
        float distancia = VectorDeDistancia.magnitude;
        speed = Mathf.Lerp(distancia, 0, Time.deltaTime);
        return Vector3.Normalize(VectorDeDistancia) * speed;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BalaJugador"))
        {
            ContadorScore.valorScore += 1;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bala2Jugador"))
        {
            ContadorScore.valorScore += 2;
            Destroy(gameObject);
        }

        if (ContadorScore.valorScore == 3)
        {
            SceneManager.LoadScene("SceneVictoria");
        }
    }
}
