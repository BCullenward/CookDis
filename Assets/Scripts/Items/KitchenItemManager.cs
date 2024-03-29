using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class KitchenItemManager : MonoBehaviour
    {
        [SerializeField] private KitchenItemsSOManager kitchenItemSO;

        private IKitchenItemParentManager kitchenItemParent;

        public KitchenItemsSOManager GetKitchenItemsSO()
        {
            return kitchenItemSO;
        }

        public void SetKitchenItemParent(IKitchenItemParentManager kitchenItemParent)
        {
            // this is for the previous clear counter (this signifies previous and parameter passed in is current)
            if (this.kitchenItemParent != null)
            {
                this.kitchenItemParent.ClearKitchenItem();
            }

            // this sets the new clear counter and moves the visual of the object (this signifies previous and parameter passed in is current)
            this.kitchenItemParent = kitchenItemParent;
            if (kitchenItemParent.HasKitchenItem())
            {
                Debug.Log("IKitchenItemParentManager already has a kitchen item, this should never happen but then the journey to Balmer's peak is a strange one");
            }

            kitchenItemParent.SetKitchenItem(this);

            transform.parent = kitchenItemParent.GetKitchenItemFollowTransform();
            transform.localPosition = Vector3.zero;
        }

        public IKitchenItemParentManager GetKitchenItemParent()
        {
            return kitchenItemParent;
        }

        public void DestroySelf()
        {
            kitchenItemParent.ClearKitchenItem();
            Destroy(gameObject);
        }

        public bool TryToGetPlate(out PlateKitchenItemManager plateKitchenItem)
        {
            if (this is PlateKitchenItemManager)
            {
                plateKitchenItem = this as PlateKitchenItemManager;
                return true;
            }
            else
            {
                plateKitchenItem = null;
                return false;
            }
        }


        public static KitchenItemManager SpawnKitchenItem(KitchenItemsSOManager kitchenItemsSO, IKitchenItemParentManager kitchenItemParent)
        {

            Transform kitchenItemTransform = Instantiate(kitchenItemsSO.prefab);
            KitchenItemManager kitchenItem = kitchenItemTransform.GetComponent<KitchenItemManager>();
            kitchenItem.SetKitchenItemParent(kitchenItemParent);

            return kitchenItem;
        }

    }
}
