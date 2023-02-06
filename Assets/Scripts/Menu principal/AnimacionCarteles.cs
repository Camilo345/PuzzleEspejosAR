using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCarteles : MonoBehaviour
{
    public Animator anim;
    public bool estado;
    [SerializeField]
    private int numCartel = 0;
    private ControlMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControlMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        animacionCrecer(menu.numeroBoton);
    }

    void animacionCrecer(int num)
    {
        if(num == numCartel)
        {
            anim.SetBool("seleccionado", true);
        }
        else
        {
            anim.SetBool("seleccionado", false);
        }
     
    }
}
