using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class SelectedAnimalVisualManager : MonoBehaviour
    {
        [SerializeField] private AnimalManager animal;
        [SerializeField] private GameObject[] visualGameObjectArray;

        private void Start()
        {
            PlayerManager.Instance.OnSelectedAnimalChanged += PlayerManager_OnSelectedAnimalChanged;
        }

        private void PlayerManager_OnSelectedAnimalChanged(object sender, PlayerManager.OnSelectedAnimalChangedEventArgs e)
        {
            if (e.selectedAnimal == animal)
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
