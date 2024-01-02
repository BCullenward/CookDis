using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CookDis
{
    public class CounterManager : MonoBehaviour, IKitchenItemParentManager
    {
        public static event EventHandler OnAnyItemPlacedHere;

        [SerializeField] private Transform counterTopPoint;

        private KitchenItemManager kitchenItem;

        public virtual void Interact(PlayerManager player)
        {
        }

        public virtual void InteractAlternate(PlayerManager player)
        {
        }

        public Transform GetKitchenItemFollowTransform()
        {
            return counterTopPoint;
        }

        public void SetKitchenItem(KitchenItemManager kitchenItem)
        {
            this.kitchenItem = kitchenItem;

            if (kitchenItem != null)
            {
                OnAnyItemPlacedHere?.Invoke(this, EventArgs.Empty);
            }
        }

        public KitchenItemManager GetKitchenItem()
        {
            return kitchenItem;
        }

        public void ClearKitchenItem()
        {
            kitchenItem = null;
        }

        public bool HasKitchenItem()
        {
            return kitchenItem != null;
        }
    }
}
