using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionEspejos : MonoBehaviour
{
    public List<GameObject> listaEspejos;
    public int totalEspejos;
    public GameObject panel;
    public GameObject botonEspejos;

    [SerializeField]
    private GameObject espejoSeleccionado;

    public delegate void eventoEmpezar();
    public static event eventoEmpezar empezar;
    private void OnEnable()
    {
       // empezar();
    }
    // Start is called before the first frame update
    void Start()
    {
      
      //  botonEspejos = GameObject.FindGameObjectWithTag("BTespejos");
        totalEspejos = listaEspejos.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void desactivarEspejos()
    {
        for(int i = 0; i < listaEspejos.Count; i++)
        {
            listaEspejos[i].SetActive(false);
        }
    }

    public void activarUnEspejo()
    {
      //  panel = GameObject.FindGameObjectWithTag("Panel");
        for (int i = 0; i < listaEspejos.Count; i++)
        {
            if (!listaEspejos[i].activeInHierarchy)
            {
                listaEspejos[i].SetActive(true);
                espejoSeleccionado = listaEspejos[i];
                panel.SetActive(true);
                botonEspejos.SetActive(false);
                break;
            }
        }
    }

    public void moverEspejo(Vector3 posicionNueva)
    {
        Vector3 posAuxiliar = espejoSeleccionado.transform.localPosition;
        posAuxiliar += posicionNueva;
        if (posAuxiliar.z <= 4.4f && posAuxiliar.z>=0 && posAuxiliar.x <= 6.7f && posAuxiliar.x>=0)
        {
            espejoSeleccionado.transform.localPosition = posAuxiliar;
        }
    }

    public void restarTotalEspejos()
    {
        totalEspejos--;
    }
}
