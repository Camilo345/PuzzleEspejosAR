using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonesUI : MonoBehaviour
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

    public void btReintentar()
    {
        int escena = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escena);
    }

    public void btVolver()
    {
        SceneManager.LoadScene(0);

    }

    public void btEmpezar()
    {
        presiono();
    }
}
