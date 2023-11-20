using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class PlateKitchenItemManager : KitchenItemManager, IHasIconsManager
    {
        public event EventHandler<IHasIconsManager.OnIngredientAddedEventArgs> OnIngredientAdded;
        //public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
        //public class OnIngredientAddedEventArgs : EventArgs
        //{
        //    public KitchenItemsSOManager kitchenItemsSO;
        //}


        [SerializeField] private List<KitchenItemsSOManager> validKitchenItemsSOList;

        private List<KitchenItemsSOManager> kitchenItemsSOList;

        private void Awake()
        {
            kitchenItemsSOList = new List<KitchenItemsSOManager>();
        }


        public bool TryToAddIngredient(KitchenItemsSOManager kitchenItemSO)
        {
            if (!validKitchenItemsSOList.Contains(kitchenItemSO))
            { // item is not in valid list of ingredients
                return false;
            }

            if (kitchenItemsSOList.Contains(kitchenItemSO))
            { // item already exists, so it will not add.  these recipes do not have more than one item of each type, if that changes this will need to be fixed
                return false;
            }
            else
            {
                kitchenItemsSOList.Add(kitchenItemSO);

                OnIngredientAdded?.Invoke(this, new IHasIconsManager.OnIngredientAddedEventArgs
                {
                    kitchenItemsSO = kitchenItemSO
                });

                return true;
            }
        }

        public List<KitchenItemsSOManager> GetKitchenItemsSOList()
        {
            return kitchenItemsSOList;
        }

    }
}
