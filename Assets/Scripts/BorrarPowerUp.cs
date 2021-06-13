using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorrarPowerUp : MonoBehaviour
{    
    public Text TextoDisparoSecundarioActivado;
    void Start()
    {
        
        //TextoDisparoSecundarioActivado = GetComponent<Text>();
                
        TextoDisparoSecundarioActivado.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            TextoDisparoSecundarioActivado.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
