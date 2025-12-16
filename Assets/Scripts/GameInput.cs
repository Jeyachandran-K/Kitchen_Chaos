using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {  get; private set; }

    public event EventHandler OnInteraction;

    private PlayerInputAction playerInputActions;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputAction();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteraction?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 GetNormalizedMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        
        inputVector = inputVector.normalized;

        return inputVector;
    }

}
