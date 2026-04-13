using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TrackingImageController : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject fcbPrefab;

    private GameObject prefabCopy;

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedChanged;
    }

    private void OnDisable()
    {
        
    }

    void OnTrackedChanged(ARTrackedImagesChangedEventArgs eventargs)
    {
        foreach(var newImage in eventargs.added)
        {
            if(newImage.referenceImage.name == "fcb")
            {
                prefabCopy = Instantiate(fcbPrefab, newImage.transform.position, newImage.transform.rotation);
            }
        }

        foreach (var newImage in eventargs.removed)
        {
            //Eliminar prefab
            if (newImage.referenceImage.name == "fcb")
            {
                Destroy(prefabCopy);
            }
        }

        foreach (var newImage in eventargs.updated)
        {
            //Esto es cada frame que sigue detectando
        }
    }
}
