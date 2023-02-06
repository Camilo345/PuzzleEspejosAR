using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGlobal : MonoBehaviour
{
    public static Transform posicionPlano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetPosicionPlano()
    {
        return posicionPlano;
    }

    public void SetPosicionPlano(Transform nuevoPosicion)
    {
        posicionPlano = nuevoPosicion; 
    }

}
