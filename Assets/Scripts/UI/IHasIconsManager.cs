using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public interface IHasIconsManager
    {
        public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
        public class OnIngredientAddedEventArgs : EventArgs
        {
            public KitchenItemsSOManager kitchenItemsSO;
        }

        public List<KitchenItemsSOManager> GetKitchenItemsSOList();
        

    }
}
