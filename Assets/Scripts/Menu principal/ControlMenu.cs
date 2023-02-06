using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public Camera cam;
    public GameObject panel;
    public GameObject punto;
    public int numeroBoton = 0;
    public Animator anim;

    private RaycastHit hit;
    private Ray ray;
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
                anim.SetBool("Aparecer", true);
                numeroBoton = 1;
            }
            else if (hit.collider.gameObject.CompareTag("Empezar"))
            {
                numeroBoton = 2;
                anim.SetBool("Aparecer", true);
            }
            else
            {
                numeroBoton = 0;
                anim.SetBool("Aparecer", false);
            }
        }
        else
        {
            numeroBoton = 0;
            anim.SetBool("Aparecer", false);
        }
        
    }

    public void cambiatEscena()
    {
        if (numeroBoton == 1)
        {
            panel.SetActive(true);
            puedoLanzar = false;
            punto.SetActive(false);
        }

        if (numeroBoton == 2)
        {
            SceneManager.LoadScene(4);
        }
    }

    void cambiarVolverALanzar()
    {
        puedoLanzar = true;
        punto.SetActive(true);
    }
}
