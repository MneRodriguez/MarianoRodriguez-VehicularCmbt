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
        
    void Start()
    {
        rbEnem = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        InvokeRepeating("SetDestino", 2f, 1f);

    }
        
    void Update()
    {
        
    }
    
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
