using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DesactivarBoton : MonoBehaviour
{
    public GameObject boton;

    private bool estaActivo=true;
    private void OnEnable()
    {
        botonesMoverEspejp.activarPanel += DesactivarActivarBoton;
    }

    private void OnDisable()
    {
        botonesMoverEspejp.activarPanel -= DesactivarActivarBoton;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DesactivarActivarBoton()
    {
        estaActivo = !estaActivo;
        boton.SetActive(estaActivo);
    }
}
