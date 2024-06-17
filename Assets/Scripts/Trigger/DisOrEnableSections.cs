using UnityEngine;

namespace Trigger
{
    public class DisOrEnableSections : MonoBehaviour
    {
        [SerializeField] private GameObject section;
        [SerializeField] private bool elevator;
        private bool _hasTriggered;
  
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
            if (section != null)
            {
                if (typeEvent == TypeEvent.Disable)
                {
                    section.SetActive(false);
                }

                if (typeEvent == TypeEvent.Enable)
                {
                    section.SetActive(true);
                    
                    if (elevator)
                    {
                        Debug.Log("enabling the elevator");
                        GameManager.Instance._xrKnob.enabled = true;
                    }
                }
            }
        }
    }
}
