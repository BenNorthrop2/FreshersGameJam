using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputActions inputActions;

    private void Awake() 
    {
        inputActions = new InputActions();
    }

    private void OnEnable() 
    {
        inputActions.Enable();
    }

    private void OnDisable() 
    {
        inputActions.Disable();
    }

    public Vector2 GetMovementAxis()
    {
        return inputActions.Movement.Move.ReadValue<Vector2>();
    }



}
