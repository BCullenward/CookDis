using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    [CreateAssetMenu()]
    public class SFXSOManager : ScriptableObject
    {
        public AudioClip[] chop;
        public AudioClip[] deliveryFail;
        public AudioClip[] deliverySuccess;
        public AudioClip[] footstep;
        public AudioClip[] objectDrop;
        public AudioClip[] objectPickup;
        public AudioClip stoveSizzle;
        public AudioClip[] trash;
        public AudioClip[] warning;


    }
}
