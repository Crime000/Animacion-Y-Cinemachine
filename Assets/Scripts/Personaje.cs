using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    Rigidbody fisicas;
    Animator animator;
    public ParticleSystem particulas;
    public Transform jugadorTransform;
    public string TriggerPart;
    public float velocidadNormal, velocidadActual, velRotacion;


    // Start is called before the first frame update
    void Start()
    {
        particulas.Stop();
        animator = GetComponent<Animator>();
        fisicas = GetComponent<Rigidbody>();
        velocidadActual = velocidadNormal;
    }

    void Update()                                                              //---Rotación                 
    {
        if (Input.GetKey(KeyCode.A))
        {
            jugadorTransform.Rotate(0, -velRotacion * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            jugadorTransform.Rotate(0, velRotacion * Time.deltaTime, 0);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TriggerPart))
        {
            Debug.Log("Particulas Activadas");
            particulas.Play();
        }
    }

    private void FixedUpdate()                                                    //---Movimiento del jugador
    {
        if (Input.GetKey(KeyCode.S))
        {
            fisicas.velocity = transform.forward * velocidadActual * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            fisicas.velocity = -transform.forward * velocidadActual * Time.deltaTime;
        }
    }
}
