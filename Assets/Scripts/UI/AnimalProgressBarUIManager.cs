using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CookDis
{
    public class AnimalProgressBarUIManager : MonoBehaviour
    {
        [SerializeField] private BisonManager bison;
        [SerializeField] private Image barImage;

        //private void Start()
        //{
        //    bison.OnProgressChanged += Bison_OnProgressChanged;
        //    barImage.fillAmount = 0f;
        //    Hide();
        //}

        //private void Bison_OnProgressChanged(object sender, BisonManager.OnProgressChangedEventArgs e)
        //{
        //    barImage.fillAmount = e.progressNormalized;

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
