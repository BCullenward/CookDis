using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class SFXManager : MonoBehaviour
    {
        public static SFXManager Instance { get; private set; }
        [SerializeField] private SFXSOManager sfxSO;

        private void Awake()
        {
            Instance = this;
        }


        private void Start()
        {
            DeliveryManagerManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
            DeliveryManagerManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
            CuttingCounterManager.OnAnyCut += CuttingCounterManager_OnAnyCut;
            PlayerManager.Instance.OnItemPickup += Player_OnItemPickup;
            CounterManager.OnAnyItemPlacedHere += CounterManager_OnAnyItemPlacedHere;
            TrashCounterManager.OnAnyItemTrashed += TrashCounterManager_OnAnyItemTrashed;
        }

        private void TrashCounterManager_OnAnyItemTrashed(object sender, System.EventArgs e)
        {
            TrashCounterManager trashCounter = sender as TrashCounterManager;
            PlaySound(sfxSO.trash, trashCounter.transform.position);
        }

        private void CounterManager_OnAnyItemPlacedHere(object sender, System.EventArgs e)
        {
            CounterManager counter = sender as CounterManager;
            PlaySound(sfxSO.objectDrop, counter.transform.position);
        }

        private void Player_OnItemPickup(object sender, System.EventArgs e)
        {
            PlaySound(sfxSO.objectPickup, PlayerManager.Instance.transform.position);
        }

        private void CuttingCounterManager_OnAnyCut(object sender, System.EventArgs e)
        {
            CuttingCounterManager cuttingCounter = sender as CuttingCounterManager;
            PlaySound(sfxSO.chop, cuttingCounter.transform.position);
        }

        private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
        {
            DeliveryCounterManager deliveryCounter = DeliveryCounterManager.Instance;
            PlaySound(sfxSO.deliverySuccess, deliveryCounter.transform.position);
        }

        private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
        {
            DeliveryCounterManager deliveryCounter = DeliveryCounterManager.Instance;
            PlaySound(sfxSO.deliveryFail, deliveryCounter.transform.position);
        }
        private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
        {
            PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
        }

        private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
        {
            AudioSource.PlayClipAtPoint(audioClip, position, volume);
        }

        public void PlayFootstepsSFX(Vector3 position, float volume)
        {
            PlaySound(sfxSO.footstep, position, volume);
        }

    }
}
