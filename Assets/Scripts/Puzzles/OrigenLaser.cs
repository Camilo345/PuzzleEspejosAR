using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigenLaser : MonoBehaviour
{
    public int rebotes;
    public Transform puntoInicio;

    private LineRenderer renderLaser;
    private RaycastHit hit;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        renderLaser = GetComponent<LineRenderer>();
        renderLaser.SetPosition(0, puntoInicio.forward);
    }

    // Update is called once per frame
    void Update()
    {

        lanzarRayo(transform.position, transform.right);
    }

    void lanzarRayo(Vector3 posicion, Vector3 direccion)
    {
        renderLaser.SetPosition(0, puntoInicio.position);
        for(int i = 0; i < rebotes; i++)
        {
            ray = new Ray(posicion, direccion);
            if(Physics.Raycast(ray,out hit, 100))
            {
                Debug.DrawRay(posicion, direccion*hit.distance, Color.green);
                posicion = hit.point;
                direccion = Vector3.Reflect(ray.direction, hit.normal);
                Debug.DrawRay(posicion, direccion * hit.distance, Color.green);
                 renderLaser.SetPosition(i + 1, hit.point);
                /* if (!hit.transform.CompareTag("Espejo"))
                 {
                     for (int j = (i + 1); j <= rebotes; j++)
                     {
                         renderLaser.SetPosition(j, hit.point);
                     }
                     break;
                 }*/
                if (hit.collider.gameObject.CompareTag("Objetivo"))
                {
                    Debug.Log("CheckMate");
                }
            }
        }
    }
}
