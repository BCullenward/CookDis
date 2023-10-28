using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class SelectedCounterVisualManager : MonoBehaviour
    {
        [SerializeField] private ClearCounterManager clearCounterManager;
        [SerializeField] private GameObject visualGameObject;

        private void Start()
        {
            PlayerManager.Instance.OnSelectedCounterChanged += PlayerManager_OnSelectedCounterChanged;
        }

        private void PlayerManager_OnSelectedCounterChanged(object sender, PlayerManager.OnSelectedCounterChangedEventArgs e)
        {
            if (e.selectedCounter == clearCounterManager)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            visualGameObject.SetActive(true);
        }

        private void Hide()
        {
            visualGameObject.SetActive(false);
        }

    }
}
