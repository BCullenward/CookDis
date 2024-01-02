using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CookDis
{
    public class TrashCounterManager : CounterManager
    {
        public static event EventHandler OnAnyItemTrashed;

        public override void Interact(PlayerManager player)
        {
            if (player.HasKitchenItem())
            {
                OnAnyItemTrashed?.Invoke(this, EventArgs.Empty);
                player.GetKitchenItem().DestroySelf();
            }
        }
    }
}
