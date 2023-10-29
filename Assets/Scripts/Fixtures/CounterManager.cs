using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class CounterManager : MonoBehaviour, IKitchenItemParentManager
    {

        [SerializeField] private Transform counterTopPoint;

        private KitchenItemManager kitchenItem;

        public virtual void Interact(PlayerManager player)
        {
        }

        public Transform GetKitchenItemFollowTransform()
        {
            return counterTopPoint;
        }

        public void SetKitchenItem(KitchenItemManager kitchenItem)
        {
            this.kitchenItem = kitchenItem;
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
