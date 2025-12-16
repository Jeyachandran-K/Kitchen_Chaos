using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {  get; private set; }

    private PlayerInputAction playerInputActions;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputAction();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetNormalizedMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        
        inputVector = inputVector.normalized;

        return inputVector;
    }

}
