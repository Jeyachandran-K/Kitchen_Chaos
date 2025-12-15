using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private void Update()
    {
        Vector2 inputVector  = Vector2.zero;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            inputVector.y = 1;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            inputVector.y = -1;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            inputVector.x = -1;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            inputVector.x = 1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        transform.position += moveDir*Time.deltaTime*playerSpeed ;


    }
}
