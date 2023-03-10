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
    public Material material1;
    public Camera cam;
    public LayerMask layer;
    RaycastHit hit;
    private Ray ray;
    Vector3 posMouse;

    private ARTrackedImageManager imageTracker;
    private List<ARPlane> planos = new List<ARPlane>();

    private  GameObject model3DPlaced;

    private void OnEnable()
    {
        imageTracker = FindObjectOfType<ARTrackedImageManager>();
        imageTracker.trackedImagesChanged += OnImageChanged;
        PlaneManager.planesChanged += PlanesFound;

    }

    private void OnDisable()
    {
        imageTracker.trackedImagesChanged -= OnImageChanged;
        PlaneManager.planesChanged -= PlanesFound;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
      
    }

    private void Start()
    {

    /*    GameObject[] ListaARsession = GameObject.FindGameObjectsWithTag("ARSession");
        if (ListaARsession.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }*/
       
    }
  

    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && model3DPlaced != null)
        {
            posMouse = Input.mousePosition;
            posMouse = cam.ScreenToWorldPoint(posMouse);
         
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Respawn"))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = material1;
                }
                
            }
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
