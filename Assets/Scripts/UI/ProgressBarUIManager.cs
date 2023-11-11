using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CookDis
{
    public class ProgressBarUIManager : MonoBehaviour
    {
        [SerializeField] private CuttingCounterManager cuttingCounter;
        [SerializeField] private Image barImage;

        private void Start()
        {
            cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;
            barImage.fillAmount = 0f;
            Hide();
        }

        private void CuttingCounter_OnProgressChanged(object sender, CuttingCounterManager.OnProgressChangedEventArgs e)
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