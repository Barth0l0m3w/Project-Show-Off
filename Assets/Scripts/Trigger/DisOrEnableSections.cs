using UnityEngine;

namespace Trigger
{
    public class DisOrEnableSections : MonoBehaviour
    {
        [SerializeField] private GameObject section;
        private bool _hasTriggered;

        /*private void OnEnable()
    {
        
    }*/

        public enum TypeEvent
        {
            Enable,
            Disable
        }

        public TypeEvent typeEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (_hasTriggered) return; //flag
            DisOrEnable();
        }
    
        private void DisOrEnable()
        {
            if (typeEvent == TypeEvent.Disable)
            {
                section.SetActive(false);
            }
            if (typeEvent == TypeEvent.Enable)
            {
                section.SetActive(true);
            }
        }
    }
}
