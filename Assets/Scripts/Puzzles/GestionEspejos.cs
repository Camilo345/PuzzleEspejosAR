using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionEspejos : MonoBehaviour
{
    public List<GameObject> listaEspejos;
    public int totalEspejos;
    public int espejosRestantes;
    public GameObject panel;
    public GameObject botonEspejos;
    public Vector3 posLaser;
    public Vector3 posObjetivo;

   
    [SerializeField]
    private GameObject espejoSeleccionado;
    private GirarEspejo girarEsp;
    [SerializeField]
    private List<Transform> posicionObstaculos = new List<Transform>();

    public delegate void eventoEmpezar();
    public static event eventoEmpezar empezarPu;

  

    // Start is called before the first frame update
    void Start()
    {
     
        botonEspejos = GameObject.FindGameObjectWithTag("BTespejos");
        totalEspejos = listaEspejos.Count;
        espejosRestantes = totalEspejos;
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
        panel = GameObject.FindGameObjectWithTag("Panel");
        for (int i = 0; i < listaEspejos.Count; i++)
        {
            if (!listaEspejos[i].activeInHierarchy)
            {
                listaEspejos[i].SetActive(true);
                espejoSeleccionado = listaEspejos[i];
                girarEsp = espejoSeleccionado.GetComponent<GirarEspejo>();
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
        if (revisarPosicion(posAuxiliar)){
            espejoSeleccionado.transform.localPosition = posAuxiliar;
        }
    }

    bool revisarPosicion(Vector3 posAuxiliar)
    {
        bool vacio = false;
    
        if (posAuxiliar.z <= 4.4f && posAuxiliar.z >= 0 && posAuxiliar.x <= 6.7f && posAuxiliar.x >= 0)
        {
            if (posAuxiliar != posLaser && posAuxiliar != posObjetivo)
            {

                vacio = true;
            }
        }
        for (int i = 0; i < posicionObstaculos.Count; i++)
        {
            if (posAuxiliar == posicionObstaculos[i].localPosition)
            {
                vacio = false;
            }
        }
        return vacio;
    }

    public void restarTotalEspejos()
    {
        posicionObstaculos.Add(espejoSeleccionado.transform);
        espejosRestantes--;
    }

    public void girarEspejo()
    {
        girarEsp.AnimacionGirar();
    }
}
