using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{

   private PlayerInput playerInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input Manager

        /*if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) //Primer frame que el dedo toca la pantalla
            {

            }
            
            if (touch.phase == TouchPhase.Moved) //Detecte si el dedo esta en una posicion distinta a la del frame anterior
            {

            }

            if(touch.phase == TouchPhase.Stationary) //Mira si el dedo esta en la misma posicion que en frame anterior
            {

            }

            if(touch.phase == TouchPhase.Ended) //Frame despues de que el dedo haya dejado de tocar la pantalla
            {

            }
            if(touch.phase == TouchPhase.Canceled) //Frame despues de que el dedo haya dejado de tocar la pantalla
            {

            }
            
        //touch.position Es la posicion en pixeles de la pantalla del dedo
    }*/

    //Input System


}

    public void TouchScreen(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            Vector2 touchPos = playerInput.actions["TouchPosition"].ReadValue<Vector2>();
        }
        if(context.phase == InputActionPhase.Performed)
        {

        }
    }
}
