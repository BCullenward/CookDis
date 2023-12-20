using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class DeliveryManagerUIManager : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private Transform recipeTemplate;


        private void Awake()
        {
            recipeTemplate.gameObject.SetActive(false);
        }

        private void Start()
        {
            DeliveryManagerManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
            DeliveryManagerManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;

            UpdateVisual();
        }

        private void DeliveryManager_OnRecipeCompleted(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void DeliveryManager_OnRecipeSpawned(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            foreach (Transform child in container)
            {
                if (child == recipeTemplate) continue;
                Destroy(child.gameObject);
            }

            foreach(RecipeSOManager recipeSO in DeliveryManagerManager.Instance.GetWaitingRecipeSOList())
            {
                Transform recipeTransform = Instantiate(recipeTemplate, container);
                recipeTransform.gameObject.SetActive(true);
                recipeTransform.GetComponent<DeliveryManagerSingleUIManager>().SetRecipeSO(recipeSO);
            }
        }
    }
}
