using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TrackingImageController : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject fcbPrefab;
    [SerializeField] private ARObjects[] objetosAR;
    [SerializeField] private BattleManager battleManager;

    private Dictionary<string, GameObject> prefabsCopy;


    private void Start()
    {
        prefabsCopy = new Dictionary<string, GameObject>();
    }
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
        foreach (var newImage in eventargs.added)
        {
            for (int i = 0; i < objetosAR.Length; i++)
            {
                if (objetosAR[i].referenceImageName == newImage.referenceImage.name)
                {
                    GameObject newPrefab = Instantiate(objetosAR[i].prefab, newImage.transform.position, newImage.transform.rotation);
                    prefabsCopy.Add(newImage.referenceImage.name, newPrefab);
                    battleManager.AddFighter(newPrefab);
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
            Debug.Log("Imagen actualizada: " + newImage.referenceImage.name);
            //Esto es cada frame que sigue detectando

            for (int i = 0; i < objetosAR.Length; i++)
            {
                if (objetosAR[i].referenceImageName == newImage.referenceImage.name && !prefabsCopy.ContainsKey(newImage.referenceImage.name))
                {
                    GameObject newPrefab = Instantiate(objetosAR[i].prefab, newImage.transform.position, newImage.transform.rotation);
                    prefabsCopy.Add(newImage.referenceImage.name, newPrefab);
                    battleManager.AddFighter(newPrefab);
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
