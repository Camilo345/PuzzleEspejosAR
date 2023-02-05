using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigenLaser : MonoBehaviour
{
    public int rebotes;
    public Transform puntoInicio;
    public LineRenderer renderLaser;

    private RaycastHit hit;
    private Ray ray;
    private bool gano=false;
    [SerializeField]
    private Material mat;
    private CalcularPuntaje puntaje;

    private void OnEnable()
    {
        EmpezarBT.presiono += llamarALanzarRayo;
    }
    private void OnDisable()
    {
        EmpezarBT.presiono -= llamarALanzarRayo;
    }
    // Start is called before the first frame update
    void Start()
    {
        puntaje = GameObject.FindGameObjectWithTag("GameController").GetComponent<CalcularPuntaje>();
        renderLaser.SetPosition(0, puntoInicio.forward);
    }

    void llamarALanzarRayo()
    {
        lanzarRayo(transform.position, transform.right);
    }
    void lanzarRayo(Vector3 posicion, Vector3 direccion)
    {
        renderLaser.SetPosition(0, puntoInicio.position);
        for(int i = 1; i < rebotes; i++)
        {
            ray = new Ray(posicion, direccion);
            Debug.DrawRay(posicion, direccion * hit.distance, Color.green);
            if (Physics.Raycast(ray,out hit, 100))
            {
              
                posicion = hit.point;
                direccion = Vector3.Reflect(ray.direction, hit.normal);
                renderLaser.SetPosition(i, posicion);
                Debug.DrawRay(posicion, direccion * hit.distance, Color.green);
                if (hit.collider.gameObject.CompareTag("Objetivo"))
                {
                    Debug.Log("checkmate");
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = mat;
                    break;
                }
                if (hit.transform.tag!="Espejo")
                 {
                    Debug.Log("Pared");
                    renderLaser.positionCount--;
                    break;
                 }
               
            }
        }
        puntaje.abrirPanel();
    }
}
