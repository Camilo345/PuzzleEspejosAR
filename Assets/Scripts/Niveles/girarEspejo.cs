using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girarEspejo : MonoBehaviour
{
    public float angle;
    public bool puedeGirar = false;

    private Quaternion rotacionInicial;
    // Start is called before the first frame update
    void Start()
    {
        rotacionInicial = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeGirar)
        {
            transform.Rotate(angle * Vector3.up, Space.World);
        }
        else
        {
            transform.rotation = rotacionInicial;
        }
        
    }
}
