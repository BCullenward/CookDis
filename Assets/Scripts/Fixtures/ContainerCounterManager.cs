using System;
using UnityEngine;

namespace CookDis
{
    public class ContainerCounterManager : CounterManager, IKitchenItemParentManager
    {
        public event EventHandler OnPlayerGrabbedItem;


        [SerializeField] private KitchenItemsSOManager kitchenItemsSO;

        public override void Interact(PlayerManager player)
        {
            // if player not carrying anything spawn it
            if (!player.HasKitchenItem())
            {
                Transform kitchenItemTransform = Instantiate(kitchenItemsSO.prefab);
                kitchenItemTransform.GetComponent<KitchenItemManager>().SetKitchenItemParent(player);

                OnPlayerGrabbedItem?.Invoke(this, EventArgs.Empty);
            }
        }




    }
}
