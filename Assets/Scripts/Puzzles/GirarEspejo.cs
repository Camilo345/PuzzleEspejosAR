using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarEspejo : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimacionGirar()
    {
        anim.SetTrigger("Girar");
    }
}
