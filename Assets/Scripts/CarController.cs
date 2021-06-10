using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider RuedaFrntIzq;
    public WheelCollider RuedaFrntDer;
    public WheelCollider RuedaTraseraIzq;
    public WheelCollider RuedaTraseraDer;

    public Transform RuedaFrntIzqTransfm;
    public Transform RuedaFrntDerTransfm;
    public Transform RuedaTraseraIzqTransfm;
    public Transform RuedaTraseraDerTransfm;

    public float anguloGiro = 45;
    public float maxTorque = 1000;
    public float maxTorqueFreno = 500;

    public Transform centroDeMasa;

    float gravedad = 9.8f;
    bool frenado = false;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centroDeMasa.transform.localPosition;
    }

    private void FixedUpdate()
    {
        if (!frenado)
        {
            RuedaFrntIzq.brakeTorque = 0;
            RuedaFrntDer.brakeTorque = 0;
            RuedaTraseraIzq.brakeTorque = 0;
            RuedaTraseraDer.brakeTorque = 0;

            // VELOCIDAD O MOVIMIENTO DEL AUTO MEDIANTE INPUT DEL TECLADO
            RuedaTraseraIzq.motorTorque = maxTorque * Input.GetAxis("Vertical");
            RuedaTraseraDer.motorTorque = maxTorque * Input.GetAxis("Vertical");

            // CAMBIO EN LA DIRECCION DEL AUTO
            RuedaFrntIzq.steerAngle = anguloGiro * Input.GetAxis("Horizontal");
            RuedaFrntDer.steerAngle = anguloGiro * Input.GetAxis("Horizontal");
        }
    }

    void Update()
    {
        FrenoDeMano();

        // GIRO DE LAS RUEDAS
        RuedaFrntIzqTransfm.Rotate(RuedaFrntIzq.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        RuedaFrntDerTransfm.Rotate(RuedaFrntDer.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        RuedaTraseraIzqTransfm.Rotate(RuedaTraseraIzq.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        RuedaTraseraDerTransfm.Rotate(RuedaTraseraDer.rpm / 60 * 360 * Time.deltaTime, 0, 0);

        // CAMBIO EN LA DIRECCION DE LAS RUEDAS
        Vector3 temp = RuedaFrntIzqTransfm.localEulerAngles;
        Vector3 temp1 = RuedaFrntDerTransfm.localEulerAngles;

        temp.y = RuedaFrntIzq.steerAngle - RuedaFrntIzqTransfm.localEulerAngles.z;
        RuedaFrntIzqTransfm.localEulerAngles = temp;

        temp1.y = RuedaFrntDer.steerAngle - RuedaFrntDerTransfm.localEulerAngles.z;
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
}
