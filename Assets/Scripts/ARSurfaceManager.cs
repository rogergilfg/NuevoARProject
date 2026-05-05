using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARSurfaceManager : MonoBehaviour
{

    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private GameObject canvasUI;

    private GameObject currentPrefab;
    private PlayerInput playerInput;
    private bool planeVisibility = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var plane in planeManager.trackables)
        {
            plane.GetComponent<ARPlaneMeshVisualizer>().enabled = planeVisibility;
        }
    }

    public void Touchscreen(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            Vector2 touchPos = playerInput.actions["TouchPosition"].ReadValue<Vector2>();
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Has tocado un " + hit.transform.name);
                Instantiate(currentPrefab, hit.point, Quaternion.identity);
            }
        }
    }

    public void ToggleVisiblilityButton()
    {
        canvasUI.SetActive(false);
        planeVisibility = !planeVisibility;
    }

    public void OnClick(int index)
    {
        Debug.Log("Prefab seleccionado: " + currentPrefab);
        currentPrefab = prefab[index];
    }
}
