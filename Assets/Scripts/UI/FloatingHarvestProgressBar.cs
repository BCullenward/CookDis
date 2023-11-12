using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CookDis
{
    public class FloatingHarvestProgressBar : MonoBehaviour
    {
        //public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
        //public class OnProgressChangedEventArgs : EventArgs
        //{
        //    public float progressNormalized;
        //}
        [SerializeField] private Slider slider;

        //private void Start()
        //{
        //    //cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;
        //    harvest.OnProgressChanged += Harvest_OnProgressChanged;
        //    //barImage.fillAmount = 0f;
        //    slider.value = 0;

        //    Hide();
        //}


        public void UpdateHarvestBar(float currentValue, float maxValue)
        {
            Debug.Log("Update Harvest Bar");
            float normalizedValue = currentValue / maxValue;
            slider.value = normalizedValue;

            if (normalizedValue == 0f || normalizedValue == 1f)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        //private void Harvest_OnProgressChanged(object sender, HarvestManager.OnProgressChangedEventArgs e)
        //{
        //    slider.value = e.progressNormalized;

        //    if (e.progressNormalized == 0f || e.progressNormalized == 1f)
        //    {
        //        Hide();
        //    }
        //    else
        //    {
        //        Show();
        //    }
        //}



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
