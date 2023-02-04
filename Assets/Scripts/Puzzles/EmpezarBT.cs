using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarBT : MonoBehaviour
{

    public delegate void eventoBoton();
    public static event eventoBoton presiono;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void btEmpezar()
    {
        presiono();
    }
}
