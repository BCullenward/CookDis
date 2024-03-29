using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CookDis
{
    public class ProgressBarUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject hasProgressGameObject;
        [SerializeField] private Image barImage;

        private IHasProgressManager hasProgress;

        private void Start()
        {
            hasProgress = hasProgressGameObject.GetComponent<IHasProgressManager>();
            if (hasProgress == null)
            {
                Debug.LogError("Game Object " + hasProgressGameObject + " does not have a component that implements IHasPgress");
            }

            hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
            barImage.fillAmount = 0f;
            Hide();
        }

        private void HasProgress_OnProgressChanged(object sender, IHasProgressManager.OnProgressChangedEventArgs e)
        {
            barImage.fillAmount = e.progressNormalized;

            if (e.progressNormalized == 0f || e.progressNormalized == 1f)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

    }
}
