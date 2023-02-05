using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalcularPuntaje : MonoBehaviour
{
    public int puntaje;
    public List<GameObject> listaEstrellas = new List<GameObject>();
    public GameObject panel;
    public GestionEspejos espejos;

    private bool gano = false;

    private void OnEnable()
    {
        OrigenLaser.ganoPerdio += cambiarBoolGano;
    }

    private void OnDisable()
    {
        OrigenLaser.ganoPerdio -= cambiarBoolGano;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void cambiarBoolGano(bool estado)
    {
        gano = estado;
    }

    public void abrirPanel()
    {
        panel.SetActive(true);
        Calcular();
    }

    public void Calcular()
    {
        espejos = GameObject.FindGameObjectWithTag("Nivel").GetComponent<GestionEspejos>();
        int totalEspejos = espejos.totalEspejos;
        Debug.Log(totalEspejos + "");
        GameObject[] listaEspejos = GameObject.FindGameObjectsWithTag("Espejo");
        puntaje = (3 * listaEspejos.Length) / totalEspejos;
        colocarEstrellas();
    }

    void colocarEstrellas()
    {
        if (gano)
        {
            for(int i = 0; i < puntaje; i++)
            {
                if (i <= puntaje)
                {
                    listaEstrellas[i].SetActive(true);
                }
                else
                {
                    listaEstrellas[i].SetActive(false);
                }
            }
        }
    }

    public void btReintentar()
    {
        int escena = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escena);
    }

    public void btVolver()
    {
        SceneManager.LoadScene(0);
    
    }
}
