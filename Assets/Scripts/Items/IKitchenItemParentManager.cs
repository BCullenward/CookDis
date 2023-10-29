using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public interface IKitchenItemParentManager
    {
        public Transform GetKitchenItemFollowTransform();

        public void SetKitchenItem(KitchenItemManager kitchenItem);

        public KitchenItemManager GetKitchenItem();

        public void ClearKitchenItem();

        public bool HasKitchenItem();
    }
}
