using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionNivel : MonoBehaviour
{
    public Animator anim;
    public girarEspejo espejo;

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
        }
        else
        {
            animacionSeleccionado(false);
        }
    }

    void animacionSeleccionado(bool estado)
    {
        anim.SetBool("seleccionado", estado);
        espejo.puedeGirar = estado;
    }

   
}
