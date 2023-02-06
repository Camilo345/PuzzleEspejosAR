using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class botonesMoverEspejp : MonoBehaviour
{
    public GameObject panel;
    public GameObject botonEspejo;
    public GestionEspejos espejos;
    public TMP_Text textoRestantes;

    public delegate void eventoAbrirPanel();
    public static event eventoAbrirPanel activarPanel;


    // Start is called before the first frame update
    void Start()
    {
        // espejos = GameObject.FindGameObjectWithTag("Nivel").GetComponent<GestionEspejos>();
        Invoke("buscarEspejos", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buscarEspejos()
    {
        espejos = GameObject.FindGameObjectWithTag("Nivel").GetComponent<GestionEspejos>();
        textoRestantes.text = espejos.espejosRestantes + "";
    }

    public void abrirPanel()
    {
        buscarEspejos();
        if (espejos.espejosRestantes > 0)
        {
            activarPanel();
            panel.SetActive(true);
            botonEspejo.SetActive(false);
            espejos.activarUnEspejo();
        }
       
    }
    public void moverEspejoX(float dir)
    {
        buscarEspejos();
        Vector3 pos = new Vector3(dir,0,0);
        espejos.moverEspejo(pos);
    }

    public void moverEspejoZ(float dir)
    {
        buscarEspejos();
        Vector3 pos = new Vector3(0, 0, dir);
        espejos.moverEspejo(pos);
    }

    public void aceptar()
    {
        buscarEspejos();
        panel.SetActive(false);
        botonEspejo.SetActive(true);
        activarPanel();
        espejos.restarTotalEspejos();
        textoRestantes.text = espejos.espejosRestantes+"";
        if (espejos.espejosRestantes == 0)
        {

            botonEspejo.SetActive(false);
        }
    }

    public void rechazar()
    {
        buscarEspejos();
        espejos.girarEspejo();
    }
}
