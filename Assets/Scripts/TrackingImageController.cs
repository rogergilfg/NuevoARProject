using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TrackingImageController : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject fcbPrefab;
    [SerializeField] private ARObjects[] objetosAR;

    private GameObject prefabCopy;

    private void OnEnable()
    {
        //trackedImagemanager.trackedImagesChanged += OnTrackedChanged; // Sirve para enlazar acciones. Herramienta para ponerlo todo en común (llamas a un solo evento).
        trackedImageManager.trackablesChanged.AddListener(OnTrackedChanged);
    }
    private void OnDisable()
    {
        trackedImageManager.trackablesChanged.RemoveListener(OnTrackedChanged);
    }

    void OnTrackedChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventargs)
    {
        foreach (var newImage in eventargs.added) //para repasar todas las img que se han añadido.
        {
            for (int i = 0; i < objetosAR.Length; i++)
            {
                if (objetosAR[i].referenceImageName == newImage.referenceImage.name)
                {
                    prefabCopy = Instantiate(objetosAR[i].prefab, newImage.transform.position, newImage.transform.rotation);
                }
            }

        }

        foreach (var newImage in eventargs.removed) //por si la imagen no se trackea
        {
            //Eliminar el prefab
            /*if (newImage.referenceImage.name == "simpleFrame")
            {
                Destroy(prefabCopy);
            }*/
        }

        foreach (var newImage in eventargs.updated)
        {
            //Esto es cada frame que sigue detectando

            for (int i = 0; i < objetosAR.Length; i++)
            {
                if (objetosAR[i].referenceImageName == newImage.referenceImage.name && prefabCopy == null)
                {
                    prefabCopy = Instantiate(objetosAR[i].prefab, newImage.transform.position, newImage.transform.rotation);
                }
            }
        }
    }
}

[Serializable]
public class ARObjects
{
    public string referenceImageName;
    public GameObject prefab;
}
