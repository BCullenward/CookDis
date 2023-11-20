using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CookDis
{
    public class IconSingleUIManager : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void SetKitchenItemSO(KitchenItemsSOManager kitchenItemSO)
        {
            image.sprite = kitchenItemSO.sprite;
        }
    }
}
