using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public Camera cam;
    public GameObject panel;
    public GameObject punto;

    private RaycastHit hit;
    private Ray ray;
    private int numeroBoton = 0;
    private bool puedoLanzar = true;

    private void OnEnable()
    {
        BotonCerrarPanel.cerrarPanelE += cambiarVolverALanzar;
    }
    private void OnDisable()
    {
        BotonCerrarPanel.cerrarPanelE -= cambiarVolverALanzar;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puedoLanzar)
        {
            lanzarRay();
            cambiatEscena();
        }
       
    }

   void  lanzarRay()
    {
        Vector3 posMouse = punto.transform.position;
        ray = cam.ScreenPointToRay(posMouse);

        int mask = LayerMask.GetMask("interactuar");
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, mask))
        {
        
            if (hit.collider.gameObject.CompareTag("Info"))
            {
                numeroBoton = 1;
            }
            else if (hit.collider.gameObject.CompareTag("Empezar"))
            {
                numeroBoton = 2;
            
            }
            else
            {
                numeroBoton = 0;
            }
        }
        Debug.DrawRay(ray.origin, ray.direction,Color.green,100);
    }

    void cambiatEscena()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (numeroBoton == 1)
            {
                panel.SetActive(true);
                puedoLanzar = false;
                punto.SetActive(false);
            }

            if (numeroBoton == 2)
            {
                SceneManager.LoadScene(3);
            }
        }
     
    }

    void cambiarVolverALanzar()
    {
        puedoLanzar = true;
        punto.SetActive(true);
    }
}
