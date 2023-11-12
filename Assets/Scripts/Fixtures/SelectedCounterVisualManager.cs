using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class SelectedCounterVisualManager : MonoBehaviour
    {
        [SerializeField] private CounterManager counter;
        [SerializeField] private GameObject[] visualGameObjectArray;

        private void Start()
        {
            PlayerManager.Instance.OnSelectedCounterChanged += PlayerManager_OnSelectedCounterChanged;
        }

        private void PlayerManager_OnSelectedCounterChanged(object sender, PlayerManager.OnSelectedCounterChangedEventArgs e)
        {
            if (e.selectedCounter == counter)
            {
                //Debug.Log("Counter");
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            foreach (GameObject visualGameObject in visualGameObjectArray)
            {
                visualGameObject.SetActive(true);
            }
        }

        private void Hide()
        {
            foreach (GameObject visualGameObject in visualGameObjectArray)
            {
                visualGameObject.SetActive(false);
            }
        }

    }
}
