using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private PlayerInputManager playerInputManager;
        [SerializeField] private LayerMask countersLayerMask;

        private bool isWalking;
        private Vector3 lastInteractDir;

        private void Update()
        {
            HandleAllPlayerActions();
        }

        private void HandleAllPlayerActions()
        {
            HandleMovement();
            HandleInteractions();
        }

        private void HandleInteractions()
        {
            Vector2 inputVector = playerInputManager.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            if (moveDir != Vector3.zero)
            {
                lastInteractDir = moveDir;
            }

            float interactDistance = 2f;

            if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out ClearCounterManager clearCounter))
                {
                    // has clear counter
                    clearCounter.Interact();
                }
            }
        }

        public bool IsWalking()
        {
            return isWalking;
        }

        private void HandleMovement()
        {
            Vector2 inputVector = playerInputManager.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

            float playerRadius = 0.7f;
            float playerHeight = 2f;
            float moveDistance = moveSpeed * Time.deltaTime;
            bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

            if (!canMove)
            {
                // attempt only x movement
                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

                if (canMove)
                {
                    // can move only on the x
                    moveDir = moveDirX;
                }
                else
                {
                    // cannot move only on the x
                    // attempt only z movement
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                    canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                    if (canMove)
                    {
                        // can move only on the y
                        moveDir = moveDirZ;
                    }
                    else
                    {
                        // cannot move in any direction
                    }
                }
            }

            if (canMove)
            {
                transform.position += moveDir * moveDistance;
            }
            isWalking = moveDir != Vector3.zero;

            float rotateSpeed = 10f;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }


    }
}
