using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CookDis
{
    public class DeliveryManagerSingleUIManager : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI recipeNameText;
        [SerializeField] private Transform iconContainer;
        [SerializeField] private Transform iconTemplate;


        private void Awake()
        {
            iconTemplate.gameObject.SetActive(false);
        }

        public void SetRecipeSO(RecipeSOManager recipeSO)
        {
            recipeNameText.text = recipeSO.recipeName;

            foreach (Transform child in iconContainer)
            {
                if (child == iconTemplate) continue;
                Destroy(child.gameObject);
            }

            foreach (KitchenItemsSOManager kitchenItemSO in recipeSO.kitchenItemsSOList)
            {
                Transform iconTransorm = Instantiate(iconTemplate, iconContainer);
                iconTransorm.gameObject.SetActive(true);
                iconTransorm.GetComponent<Image>().sprite = kitchenItemSO.sprite;
            }

        }

    }
}
