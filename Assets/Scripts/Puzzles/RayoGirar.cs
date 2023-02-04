using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoGirar : MonoBehaviour
{
    public Camera cam;

    private Ray ray;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lanzarRayo();
        }
    }

    void lanzarRayo()
    {
         Vector3   posMouse = Input.mousePosition;
            posMouse = cam.ScreenToWorldPoint(posMouse);

            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Espejo"))
                {
                hit.collider.gameObject.GetComponent<GirarEspejo>().AnimacionGirar();
                }
            }
    }
}
