using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class AnimalManager : MonoBehaviour, IAnimalItemParentManager
    {

        private AnimalItemManager animalItem;

        public virtual void Interact(PlayerManager player)
        {
        }

        public void ClearAnimalItem()
        {
            animalItem = null;
        }

        public AnimalItemManager GetAnimalItem()
        {
            return animalItem;
        }

        //public Transform GetAnimalItemFollowTransform()
        //{
        //    throw new System.NotImplementedException();
        //}

        public bool HasAnimalItem()
        {
            return animalItem != null;
        }

        //public void SetAnimalItem(AnimalItemManager animalItem)
        //{
        //    this.animalItem = animalItem;
        //}
    }
}
