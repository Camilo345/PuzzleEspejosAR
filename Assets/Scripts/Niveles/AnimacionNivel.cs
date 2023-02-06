using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionNivel : MonoBehaviour
{
    public Animator anim;
    public int indiceNivel = 0;
    public girarEspejo espejo;
    public List<GameObject> listaEstrellas = new List<GameObject>();

    [SerializeField]
    private float dis=0;
    private RayoNivel nivel;
    // Start is called before the first frame update
    void Start()
    {
        nivel = GameObject.FindGameObjectWithTag("GameController").GetComponent<RayoNivel>();
    }

    // Update is called once per frame
    void Update()
    {
        VerificarSeleccion();
    }

    void VerificarSeleccion()
    {
        
        if (this.gameObject.name==nivel.nombre)
        {
            animacionSeleccionado(true);
            activarEstrellas(true);
        }
        else
        {
            animacionSeleccionado(false);
            activarEstrellas(false);
        }
    }

    void activarEstrellas(bool activar)
    {
        int puntaje = PlayerPrefs.GetInt("puntaje" + indiceNivel);
        Debug.Log(puntaje);
        if (puntaje == 0)
        {
            activar = false;
        }

        if (activar)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i <= puntaje)
                {
                    listaEstrellas[i].SetActive(true);
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
               
               listaEstrellas[i].SetActive(false);
                
            }
        }
     
    }

    void animacionSeleccionado(bool estado)
    {
        anim.SetBool("seleccionado", estado);
        espejo.puedeGirar = estado;
    }

   
}
