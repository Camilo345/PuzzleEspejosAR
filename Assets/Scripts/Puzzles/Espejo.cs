using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espejo : MonoBehaviour
{
    private bool puedoLanzar=false;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (puedoLanzar)
        {

        }
    }
    public void CambiarLanzarRayo()
    {
        puedoLanzar = true;
    }

   void  lanzarRayo()
    {

        if (Physics.Raycast(gameObject.transform.position, Vector3.right, out hit))
        {


            if (hit.collider.gameObject.CompareTag("Espejo"))
            {
                Debug.Log("espejo");
            }

        }
    }


}
