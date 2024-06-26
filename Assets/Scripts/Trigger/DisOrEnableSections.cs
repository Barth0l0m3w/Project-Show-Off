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
            //todo: make it check just for player and plaform
            
            if (_hasTriggered) return; //flag
            DisOrEnable();
        }
    
        private void DisOrEnable()
        {
            
            if (section != null)
            {
                if (typeEvent == TypeEvent.Disable)
                {
                    Debug.Log(gameObject.name + " is disabling: " + section.name);
                    section.SetActive(false);
                }

                if (typeEvent == TypeEvent.Enable)
                {
                    Debug.Log(gameObject.name + " is enabling: " + section.name);
                    section.SetActive(true);
                }
            }
            if (elevator)
            {
                //Debug.Log("enabling the elevator");
                //GameManager.Instance._xrKnob.enabled = true;
                GameManager.Instance._Lever.enabled = true;
            }
        }
    }
}
