using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    private DisparoJgdr tomarScrptDisparoJugdr; // NECESITO CREAR UNA VAR QUE TOME EL SCRIPT Y SUS MÉTODOS PARA PODER LLAMAR AL 2DO MODO DE DISPARO
    
    public GameObject AutoJgdr;

    public WheelCollider RuedaFrntIzq;
    public WheelCollider RuedaFrntDer;
    public WheelCollider RuedaTraseraIzq;
    public WheelCollider RuedaTraseraDer;

    public Transform RuedaFrntIzqTransfm;
    public Transform RuedaFrntDerTransfm;
    public Transform RuedaTraseraIzqTransfm;
    public Transform RuedaTraseraDerTransfm;

    public float anguloGiro = 45f;
    public float maxTorque = 600f;
    public float maxTorqueFreno = 200f;

    public Transform centroDeMasa;

    float gravedad = 9.8f;
    bool frenado = false;
    public Rigidbody rb;

    public GameObject CapsulaPowerUp; // DUPLICA PUNTAJE AL ELIMINAR AUTOS RIVALES

    void Start()
    {
        AutoJgdr = GetComponent<GameObject>();
        CapsulaPowerUp = GetComponent<GameObject>();

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centroDeMasa.transform.localPosition;

        tomarScrptDisparoJugdr = GetComponent<DisparoJgdr>();
        
    }

    /*private void actualizarPosRuedas (WheelCollider ruedaCollider, Transform ruedaTransform)
    {
        Vector3 pos = ruedaTransform.position;
        Quaternion quat = ruedaTransform.rotation;

        ruedaCollider.GetWorldPose(out pos, out quat);

        ruedaTransform.position = pos;
        ruedaTransform.rotation = quat;
    }*/
    private void FixedUpdate()
    {
        
        
        if (!frenado)
        {
            RuedaFrntIzq.brakeTorque = 0;
            RuedaFrntDer.brakeTorque = 0;
            RuedaTraseraIzq.brakeTorque = 0;
            RuedaTraseraDer.brakeTorque = 0;

            // ACELERACION DEL AUTO CON LAS RUEDAS TRASERAS E INPUT "W"
            RuedaTraseraIzq.motorTorque = maxTorque * Input.GetAxisRaw("Vertical");
            RuedaTraseraDer.motorTorque = maxTorque * Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * gravedad);
                rb.AddForce(Vector3.forward * rb.mass);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -gravedad);
            }

            Vector3 VelLocal = transform.InverseTransformDirection(rb.velocity);
            VelLocal.x = 0;
            rb.velocity = transform.TransformDirection(VelLocal);

            

            // CAMBIO EN LA DIRECCION DE LAS RUEDAS DELANTERAS
            RuedaFrntIzq.steerAngle = anguloGiro * Input.GetAxis("Horizontal");
            RuedaFrntDer.steerAngle = anguloGiro * Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.AddRelativeTorque(-Vector3.up * anguloGiro);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.AddRelativeTorque(Vector3.up * anguloGiro);
            }
        }
    }

    void Update()
    {
        
        FrenoDeMano();

        // GIRO DE LAS RUEDAS
        RuedaFrntIzqTransfm.Rotate(RuedaFrntIzq.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        RuedaFrntDerTransfm.Rotate(RuedaFrntDer.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        RuedaTraseraIzqTransfm.Rotate(0, RuedaTraseraIzq.rpm / 60 * 360 * Time.deltaTime, 0);
        RuedaTraseraDerTransfm.Rotate(0, RuedaTraseraDer.rpm / 60 * 360 * Time.deltaTime, 0);

        // CAMBIO EN LA DIRECCION DE LAS RUEDAS
        Vector3 temp = RuedaFrntIzqTransfm.localEulerAngles;
        Vector3 temp1 = RuedaFrntDerTransfm.localEulerAngles;

        temp.y = RuedaFrntIzq.steerAngle - RuedaFrntIzqTransfm.localEulerAngles.x;
        RuedaFrntIzqTransfm.localEulerAngles = temp;

        temp1.y = RuedaFrntDer.steerAngle - RuedaFrntDerTransfm.localEulerAngles.x;
        RuedaFrntDerTransfm.localEulerAngles = temp1;
    }

    void FrenoDeMano()
    {
        if (Input.GetButton("Jump")) // SI SE PRESIONA LA BARRA ESPACIADORA, FRENA
        {
            frenado = true;
        }
        else { frenado = false; }

        if (frenado)
        {
            RuedaTraseraIzq.brakeTorque = maxTorqueFreno * 20;
            RuedaTraseraDer.brakeTorque = maxTorqueFreno * 20;

            RuedaTraseraIzq.motorTorque = 0;
            RuedaTraseraDer.motorTorque = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            SceneManager.LoadScene("SceneDerrota");
        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            if (Input.GetButtonDown("Fire2"))
            {
                tomarScrptDisparoJugdr.Disparar2();
            }

            Destroy(CapsulaPowerUp);
            
            ContadorScore.valorScore += 2;            
        }
    }
}

