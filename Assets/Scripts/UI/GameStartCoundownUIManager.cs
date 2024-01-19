using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace CookDis
{
    public class GameStartCoundownUIManager : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI countdownText;

        private void Start()
        {
            GameHandlerManager.Instance.OnStateChanged += GameHandlerManager_OnStateChanged;

            Hide();
        }

        private void GameHandlerManager_OnStateChanged(object sender, EventArgs e)
        {
            if (GameHandlerManager.Instance.IsCountdownToStartActive())
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Update()
        {
            countdownText.text = Mathf.Ceil(GameHandlerManager.Instance.GetCountdownToStartTimer()).ToString();
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
