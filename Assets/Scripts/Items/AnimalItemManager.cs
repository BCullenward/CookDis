using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class AnimalItemManager : MonoBehaviour
    {
        [SerializeField] private AnimalItemsSOManager animalItemSO;

        private IAnimalItemParentManager animalItemParent;

        public AnimalItemsSOManager GetAnimalItemsSO()
        {
            return animalItemSO;
        }

        //public void SetAnimalItemParent(IAnimalItemParentManager animalItemParent)
        //{
        //    // this is for the previous animal (this signifies previous and parameter passed in is current)
        //    if (this.animalItemParent != null)
        //    {
        //        this.animalItemParent.ClearAnimalItem();
        //    }

        //    // this sets the new animal and moves the visual of the object (this signifies previous and parameter passed in is current)
        //    this.animalItemParent = animalItemParent;
        //    if (animalItemParent.HasAnimalItem())
        //    {
        //        Debug.Log("IAnimalItemParentManager already has a kitchen item, this should never happen but then the journey to Balmer's peak is a strange one");
        //    }

        //    animalItemParent.SetAnimalItem(this);

        //    //transform.parent = animalItemParent.GetAnimalItemFollowTransform();
        //    transform.localPosition = Vector3.zero;
        //}

        public IAnimalItemParentManager GetAnimalItemParent()
        {
            return animalItemParent;
        }

    }
}
