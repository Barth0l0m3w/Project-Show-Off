using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Interactors
{
    public class ResetObject : MonoBehaviour
    {
        private XRBaseInteractable _baseInteractable;

        [Tooltip("The transform that the object will return to")] [SerializeField]
        private Vector3 returnPos;

        [SerializeField] private float resetDelay;

        private bool _isController;

        private void Awake()
        {
            _baseInteractable = GetComponent<XRBaseInteractable>();
            returnPos = this.transform.position;
        }

        private void OnEnable()
        {
            _baseInteractable.selectExited.AddListener(OnSelectExit);
            _baseInteractable.selectEntered.AddListener(OnSelect);
        }

        private void OnSelectExit(SelectExitEventArgs args) => CancelInvoke("return home");
        private void OnSelect(SelectEnterEventArgs args) => Invoke(nameof(ReturnHome), resetDelay);

        private void ReturnHome()
        {
            transform.position = returnPos;
        }
    }
}
