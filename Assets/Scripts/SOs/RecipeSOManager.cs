using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    [CreateAssetMenu()]
    public class RecipeSOManager : ScriptableObject
    {
        public List<KitchenItemsSOManager> kitchenItemsSOList;
        public string recipeName;
    }
}
