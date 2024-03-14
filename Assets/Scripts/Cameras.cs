using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cameras : MonoBehaviour
{
    public string camaraTag;
    public bool dollyCam = false, OrbitCam = false, TerceraPersona = false;

    public CinemachineVirtualCamera PrimeraCamara;

    public CinemachineVirtualCamera[] camaras;

    // Start is called before the first frame update
    void Start()
    {
        CambioDeCamara(PrimeraCamara);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            if(dollyCam == false)
            {
                CinemachineVirtualCamera activa = camaras[3];
                Debug.Log("esto es: " + activa.ToString());
                CambioDeCamara(activa);
                dollyCam = true;
            }
            else if (dollyCam == true)
                 {
                      CinemachineVirtualCamera activa = camaras[0];
                      Debug.Log("esto es: " + activa.ToString());
                      CambioDeCamara(activa);
                      dollyCam = false;
                 }

        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            if (OrbitCam == false)
            {
                CinemachineVirtualCamera activa = camaras[4];
                Debug.Log("esto es: " + activa.ToString());
                CambioDeCamara(activa);
                OrbitCam = true;
            }
            else if (OrbitCam == true)
            {
                CinemachineVirtualCamera activa = camaras[0];
                Debug.Log("esto es: " + activa.ToString());
                CambioDeCamara(activa);
                OrbitCam = false;
            }

        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            if (TerceraPersona == false)
            {
                CinemachineVirtualCamera activa = camaras[5];
                Debug.Log("esto es: " + activa.ToString());
                CambioDeCamara(activa);
                TerceraPersona = true;
            }
            else if (TerceraPersona == true)
            {
                CinemachineVirtualCamera activa = camaras[0];
                Debug.Log("esto es: " + activa.ToString());
                CambioDeCamara(activa);
                TerceraPersona = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(camaraTag))
        {
            CinemachineVirtualCamera activa = other.GetComponentInChildren<CinemachineVirtualCamera>();
            CambioDeCamara(activa);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(camaraTag))
        {
            CambioDeCamara(PrimeraCamara);
        }
    }

    private void CambioDeCamara(CinemachineVirtualCamera activa)
    {
        foreach (CinemachineVirtualCamera cam in camaras)
        {
            cam.enabled = cam == activa;
        }
    }
}
