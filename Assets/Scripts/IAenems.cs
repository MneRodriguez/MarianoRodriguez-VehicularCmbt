using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class IAenems : MonoBehaviour
{
    public GameObject Enem;
    public Rigidbody rbEnem;

    public NavMeshAgent navMeshAgent;
    public Transform target;

    /*public Transform puntoDeDestino;
    Rigidbody rb;
    public float speed = 10.5f;*/
    void Start()
    {
        rbEnem = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        InvokeRepeating("SetDestino", 2f, 1f);

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

    private void SetDestino()
    {
        navMeshAgent.destination = target.position;
    }

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

        if (ContadorScore.valorScore == 3 || ContadorScore.valorScore == 4 || ContadorScore.valorScore == 5 || ContadorScore.valorScore == 6)
        {
            SceneManager.LoadScene("SceneVictoria");
        }
    }
}
