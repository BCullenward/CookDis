using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class StoveCounterSFXManager : MonoBehaviour
    {
        [SerializeField] private StoveCounterManager stoveCounter;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        }

        private void StoveCounter_OnStateChanged(object sender, StoveCounterManager.OnStateChangedEventArgs e)
        {
            bool playSound = e.state == StoveCounterManager.State.Cooking || e.state == StoveCounterManager.State.Cooked;
            if (playSound)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Pause();
            }
        }
    }
}
