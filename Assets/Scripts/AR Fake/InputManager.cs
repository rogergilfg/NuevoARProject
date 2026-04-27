using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Camera arCamera;
    [SerializeField] private UIController uiController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update corriendo");

        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Input detectado");

            Vector2 touchPosition = Input.touchCount > 0
                ? Input.GetTouch(0).position
                : (Vector2)Input.mousePosition;
            Ray ray = arCamera.ScreenPointToRay(touchPosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    uiController.AddKill();
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
