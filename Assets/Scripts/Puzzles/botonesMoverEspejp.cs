using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonesMoverEspejp : MonoBehaviour
{
    public GameObject panel;
    public GameObject botonEspejo;
    public GestionEspejos espejos;

    private void OnEnable()
    {
        GestionEspejos.empezar += buscarEspejos;
    }

    private void OnDisable()
    {
        GestionEspejos.empezar -= buscarEspejos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buscarEspejos()
    {
       // espejos = GameObject.FindGameObjectWithTag("Nivel").GetComponent<GestionEspejos>();
    }

    public void abrirPanel()
    {
        if (espejos.totalEspejos > 0)
        {
            panel.SetActive(true);
            botonEspejo.SetActive(false);
            espejos.activarUnEspejo();
        }
    }
    public void moverEspejoX(float dir)
    {
        
        Vector3 pos = new Vector3(dir,0,0);
        espejos.moverEspejo(pos);
    }

    public void moverEspejoZ(float dir)
    {
      
        Vector3 pos = new Vector3(0, 0, dir);
        espejos.moverEspejo(pos);
    }

    public void aceptar()
    {
        panel.SetActive(false);
        botonEspejo.SetActive(true);
        espejos.restarTotalEspejos();
    }

    public void rechazar()
    {
        panel.SetActive(false);
        botonEspejo.SetActive(true);
    }
}
