using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
public class PlaneManagr : MonoBehaviour
{
    public ARPlaneManager PlaneManager;
    public GameObject Cubo;

    private List<ARPlane> planos = new List<ARPlane>();
    private GameObject model3DPlaced;

    private void OnEnable()
    {
        PlaneManager.planesChanged += PlanesFound;
    }

    private void OnDisable()
    {
        PlaneManager.planesChanged -= PlanesFound;
    }

    private void Start()
    {

        GameObject[] ListaARsession = GameObject.FindGameObjectsWithTag("ARSession");
        if (ListaARsession.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
       
    }
  

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && model3DPlaced != null)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void PlanesFound(ARPlanesChangedEventArgs obj)
    {
        if(obj.added != null && obj.added.Count > 0)
        {
            planos.AddRange(obj.added);
        }

        for(int i = 0; i < planos.Count; i++)
        {
            if (planos[i].extents.x * planos[i].extents.y > 0.4f && model3DPlaced==null)
            {
                model3DPlaced = Instantiate(Cubo);
                float Yoffset = model3DPlaced.transform.localScale.y / 2;
                model3DPlaced.transform.position = new Vector3(planos[i].center.x, +planos[i].center.y+Yoffset, planos[i].center.z);
                model3DPlaced.transform.forward = planos[i].normal;
                stopPlane();
            }
        }
    }

    private void stopPlane()
    {
        PlaneManager.requestedDetectionMode = UnityEngine.XR.ARSubsystems.PlaneDetectionMode.None;
        for (int i = 0; i < planos.Count; i++)
        {
            planos[i].gameObject.SetActive(false);
        }
    }


}
