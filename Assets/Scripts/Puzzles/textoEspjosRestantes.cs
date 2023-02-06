using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textoEspjosRestantes : MonoBehaviour
{
    private TMP_Text texto;
    private GestionEspejos espejos;
    private void OnEnable()
    {
        botonesMoverEspejp.activarPanel += traerEspejo;
    }

    private void OnDisable()
    {
        botonesMoverEspejp.activarPanel -= traerEspejo;
    }
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = espejos.espejosRestantes+"";
    }

    void traerEspejo()
    {
        espejos = GameObject.FindGameObjectWithTag("Nivel").GetComponent<GestionEspejos>();
    }
}
