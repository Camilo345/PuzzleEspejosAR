using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCerrarPanel : MonoBehaviour
{
    public GameObject panel;

    public delegate void eventoCerrarPanel();
    public static event eventoCerrarPanel cerrarPanelE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cerrarPanel()
    {
        cerrarPanelE();
        panel.SetActive(false);
    }
}
