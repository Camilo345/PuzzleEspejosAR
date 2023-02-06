using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTutorial : MonoBehaviour
{
    
    
    public List<Sprite> listaPaneles = new List<Sprite>();
    public GameObject botonSiguiente;
    public GameObject botonAnterior;
    public GameObject botonCerrar;
  
    private int indice = 0;
    private Image panelSprite;
    private GameObject panel;

    public delegate void eventoCerrarPanel();
    public static event eventoCerrarPanel cerrarPanelE;

   
    // Start is called before the first frame update
    void Start()
    {
        panel = this.gameObject;
        panelSprite = GetComponent<Image>();
        cambiarPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cerrarPanel()
    {
        cerrarPanelE();
        panel.SetActive(false);
    }

    public void pasarPanel(int ind)
    {
        indice += ind;
        indice = Mathf.Clamp(indice, 0, listaPaneles.Count);
        cambiarPanel();
    }

    void cambiarPanel()
    {
        panelSprite.sprite = listaPaneles[indice];
        if (indice == 0)
        {
            botonAnterior.SetActive(false);
            botonCerrar.SetActive(false);
            botonSiguiente.SetActive(true);

        }else if(indice== listaPaneles.Count-1){
            botonAnterior.SetActive(true);
            botonCerrar.SetActive(true);
            botonSiguiente.SetActive(false);
        }
        else
        {
            botonAnterior.SetActive(true);
            botonCerrar.SetActive(false);
            botonSiguiente.SetActive(true);
        }
    }
}
