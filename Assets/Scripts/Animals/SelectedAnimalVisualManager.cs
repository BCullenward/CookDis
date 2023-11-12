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
            //Debug.Log(e.selectedAnimal + "<- selected animal -  Animal ->" + animal);
            if (e.selectedAnimal == animal)
            {
                Debug.Log("Here2");
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
