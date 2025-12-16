using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private LayerMask countersLayerMask;

    private bool isWalking;
    private Vector3 lastMoveDir;

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }
    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteraction()
    {

        Vector2 inputVector = GameInput.Instance.GetNormalizedMovementVector();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastMoveDir=moveDir;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastMoveDir, out RaycastHit raycastHit,interactDistance,countersLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetNormalizedMovementVector();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        isWalking = moveDir != Vector3.zero;

        float moveDistance = playerSpeed * Time.deltaTime;

        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + new Vector3(0, playerHeight, 0), playerRadius, moveDir, moveDistance);
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        else
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
            bool canMoveX = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            bool canMoveZ = Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
            if (canMoveX)
            {
                transform.position += moveDirX * moveDistance;
            }
            else if (canMoveZ)
            {
                transform.position += moveDirZ * moveDistance;
            }
            else
            {

            }
        }

        float rotateSpeed = 10f;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);


    }
}
