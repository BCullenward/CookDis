using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator playerAnimator;
        private const string IS_WALKING = "is_Walking";
        [SerializeField] private PlayerManager player;

        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            playerAnimator.SetBool(IS_WALKING, player.IsWalking());
        }
    }
}
