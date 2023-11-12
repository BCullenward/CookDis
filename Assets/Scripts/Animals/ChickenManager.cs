using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class ChickenManager : AnimalManager
    {
        [SerializeField] private HarvestProgressSOManager harvest;

        public override void Interact(PlayerManager player)
        {

        }
    }
}
