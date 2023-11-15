using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class TrashCounterManager : CounterManager
    {
        public override void Interact(PlayerManager player)
        {
            if (player.HasKitchenItem())
            {
                player.GetKitchenItem().DestroySelf();
            }
        }
    }
}
