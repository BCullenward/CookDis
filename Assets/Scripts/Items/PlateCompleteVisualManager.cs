using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class PlateCompleteVisualManager : MonoBehaviour
    {
        [Serializable]
        public struct KitchenItemSO_GameObject
        {
            public KitchenItemsSOManager kitchenItemSO;
            public GameObject gameObject;
        }

        [SerializeField] private PlateKitchenItemManager plateKitchenItem;
        [SerializeField] private List<KitchenItemSO_GameObject> kitchenItemSOGameObjectList;

        private void Start()
        {
            plateKitchenItem.OnIngredientAdded += PlateKitchenItem_OnIngredientAdded;

            foreach (KitchenItemSO_GameObject kitchenItemSOGameObject in kitchenItemSOGameObjectList)
            {
                kitchenItemSOGameObject.gameObject.SetActive(false);
            }
        }

        private void PlateKitchenItem_OnIngredientAdded(object sender, IHasIconsManager.OnIngredientAddedEventArgs e)
        {
            foreach (KitchenItemSO_GameObject kitchenItemSOGameObject in kitchenItemSOGameObjectList)
            {
                if (kitchenItemSOGameObject.kitchenItemSO == e.kitchenItemsSO)
                {
                    kitchenItemSOGameObject.gameObject.SetActive(true);
                }
            }
        }
    }
}
