using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class PlayerManager : MonoBehaviour
    {

        [SerializeField] private float moveSpeed = 7f;

        private void Update()
        {
            Vector2 inputVector = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.W))
            {
                inputVector.y = +1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                inputVector.y = -1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                inputVector.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                inputVector.x = +1;
            }

            inputVector = inputVector.normalized;

            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.position += moveDir * moveSpeed * Time.deltaTime;

        }
    }
}
