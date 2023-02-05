using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class PosicionarNivel : MonoBehaviour
{
    public GameObject nivel;
    public ARTrackedImageManager imageTracker;
    private Transform pos;
    private InfoGlobal info;

    private void OnEnable()
    {
        //  imageTracker.trackedImagesChanged += OnImageChanged;
        empezar.empezarP += actualizarPos;
    }
    private void OnDisable()
    {
        //imageTracker.trackedImagesChanged -= OnImageChanged;
        empezar.empezarP += actualizarPos;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void actualizarPos()
    {
        pos = GameObject.FindGameObjectWithTag("Player").transform;
        nivel.transform.position = Vector3.zero;
        nivel.transform.SetParent(pos);
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        List<Transform> listaIma=new List<Transform>();
       foreach(var imagen in obj.added)
        {
            listaIma.Add(imagen.transform);
        }
        nivel.transform.position = listaIma[0].position;
        nivel.transform.parent = listaIma[0];
    }
}
