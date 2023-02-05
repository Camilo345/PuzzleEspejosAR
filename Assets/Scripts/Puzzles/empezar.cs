using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empezar : MonoBehaviour
{

    public delegate void eventoEmpezar();
    public static event eventoEmpezar empezarP;

    private void OnEnable()
    {
        empezarP();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
