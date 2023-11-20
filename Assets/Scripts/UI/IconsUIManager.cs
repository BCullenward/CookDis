using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CookDis
{
    public class IconsUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject hasIconsUIGameObject;
        [SerializeField] private Transform iconTemplate;

        private IHasIconsManager hasIcons;

        private void Awake()
        {
            iconTemplate.gameObject.SetActive(false);
        }

        private void Start()
        {
            hasIcons = hasIconsUIGameObject.GetComponent<IHasIconsManager>();
            if (hasIcons == null)
            {
                Debug.LogError("Game Object " + hasIconsUIGameObject + " does not have a component that implements IHasIconsManager");
            }

            hasIcons.OnIngredientAdded += HasIcons_OnIngredientAdded;
            //barImage.fillAmount = 0f;
            //Hide();
        }

        public void HasIcons_OnIngredientAdded(object sender, IHasIconsManager.OnIngredientAddedEventArgs e)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            foreach (Transform child in transform)
            {
                if (child != iconTemplate)
                {
                    Destroy(child.gameObject);
                }
            }


            foreach (KitchenItemsSOManager kitchenItemsSO in hasIcons.GetKitchenItemsSOList())
            {
                Transform iconTransform = Instantiate(iconTemplate, transform);
                iconTransform.gameObject.SetActive(true);
                iconTransform.GetComponent<IconSingleUIManager>().SetKitchenItemSO(kitchenItemsSO);
            }
        }
    }
}
