using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CookDis
{
    public class PlayerInputManager : MonoBehaviour
    {
        public event EventHandler OnInteractAction;
        public event EventHandler OnInteractAlternateAction;

        private PlayerInputActions playerInputActions;

        private void Awake()
        {
            CreatePlayerInputActions();
        }
        public Vector2 GetMovementVectorNormalized()
        {
            CreatePlayerInputActions();
            Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
            inputVector = inputVector.normalized;
            return inputVector;
        }

        private void CreatePlayerInputActions()
        {
            if (playerInputActions == null)
            {
                playerInputActions = new PlayerInputActions();
                playerInputActions.Player.Enable();

                playerInputActions.Player.Interact.performed += Interact_performed;
                playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
            }
        }

        private void InteractAlternate_performed(InputAction.CallbackContext obj)
        {
            OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
        }

        private void Interact_performed(InputAction.CallbackContext obj)
        {
            OnInteractAction?.Invoke(this, EventArgs.Empty);
        }
    }
}
