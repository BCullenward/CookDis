using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class ContainerCounterVisualManager : MonoBehaviour
    {
        private const string OPEN_CLOSE = "OpenClose";

        [SerializeField] private ContainerCounterManager containerCounter;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            containerCounter.OnPlayerGrabbedItem += ContainerCounter_OnPlayerGrabbedItem;
        }

        private void ContainerCounter_OnPlayerGrabbedItem(object sender, System.EventArgs e)
        {
            animator.SetTrigger(OPEN_CLOSE);
        }
    }
}
