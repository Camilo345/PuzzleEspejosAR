using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoNivel : MonoBehaviour
{

    public Camera cam;
    public string nombre;
    public GameObject punto;

    private RaycastHit hit;
    private Ray ray;
    private bool puedoCambiar = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        lanzarRay();
        cambiarEscena();
    }

    void lanzarRay()
    {
        Vector3 posMouse = punto.transform.position;
        ray = cam.ScreenPointToRay(posMouse);

        int mask = LayerMask.GetMask("interactuar");
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 300, mask))
        {
            puedoCambiar = true;
            nombre = hit.collider.name;
           
        }
        else
        {
            puedoCambiar = false;
            nombre = "  ";
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.green,300);
    }

    void cambiarEscena()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(hit.collider.gameObject.GetComponent<Nivel>().nivel + "");
            hit.collider.gameObject.GetComponent<Nivel>().cambiarNivel();
        }
    }

}
