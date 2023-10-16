
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour
{
    public UnityEvent jump;
    public UnityEvent jumpHold;
    public UnityEvent<int> moveCheck;
    public UnityEvent Fire;

    public void OnJumpHoldAction(InputAction.CallbackContext context)
    {
        Debug.Log("jump");
        if (context.started)
        {   

        }
            
        else if (context.performed)
        {
       
            jumpHold.Invoke();
        }
        else if (context.canceled)
        {

        }
            
    }

    // called twice, when pressed and unpressed
    public void OnJumpAction(InputAction.CallbackContext context)
    {

        Debug.Log("jump");
        if (context.started)
        {

        }
        
        else if (context.performed)
        {
            jump.Invoke();
           
        }
        else if (context.canceled) { }
            

    }

    // called twice, when pressed and unpressed
    public void OnMoveAction(InputAction.CallbackContext context)
    {
        // Debug.Log("OnMoveAction callback invoked");
        if (context.started)
        {
 
            int faceRight = context.ReadValue<float>() > 0 ? 1 : -1;
   
            moveCheck.Invoke(faceRight);
        }
        if (context.canceled)
        {

            moveCheck.Invoke(0);
        }

    }
    public void OnClickAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }
        
        else if (context.performed)
        {
            
        }
        else if (context.canceled)
                {

                }
        }

    public void OnPointAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 point = context.ReadValue<Vector2>();
           

        }
    }
    public void OnFireAction(InputAction.CallbackContext context)
    {
        Debug.Log("fire detected");
        if (context.performed)
        {
           
            Fire.Invoke();


        }
    }
    public void OnFireHoldAction(InputAction.CallbackContext context)
    {
        
    }

}
