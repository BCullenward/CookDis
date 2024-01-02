using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class PlayerSFXManager : MonoBehaviour
    {
        private PlayerManager player;
        private float footstepTimer;
        private float footstepTimerMax = .1f;

        private void Awake()
        {
            player = GetComponent<PlayerManager>();
        }

        private void Update()
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer < 0f)
            {
                footstepTimer = footstepTimerMax;

                if (player.IsWalking())
                {
                    float volume = 1f;
                    SFXManager.Instance.PlayFootstepsSFX(player.transform.position, volume);
                }
            }
        }

    }
}
