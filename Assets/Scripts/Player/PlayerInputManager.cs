using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class PlayerInputManager : MonoBehaviour
    {
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
            }
        }

    }
}
