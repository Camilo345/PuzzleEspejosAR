using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalcularPuntaje : MonoBehaviour
{
    public int puntaje;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void abrirPanel()
    {
        panel.SetActive(true);
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
