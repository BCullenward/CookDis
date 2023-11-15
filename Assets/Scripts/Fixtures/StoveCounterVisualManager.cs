using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class StoveCounterVisualManager : MonoBehaviour
    {
        [SerializeField] private StoveCounterManager stoveCounter;
        [SerializeField] private GameObject stoveOnGameObject;
        [SerializeField] private GameObject particlesGameObject;

        private void Start()
        {
            stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        }

        private void StoveCounter_OnStateChanged(object sender, StoveCounterManager.OnStateChangedEventArgs e)
        {
            bool showVisual = e.state == StoveCounterManager.State.Cooking || e.state == StoveCounterManager.State.Cooked;
            stoveOnGameObject.SetActive(showVisual);
            particlesGameObject.SetActive(showVisual);
        }

    }
}
