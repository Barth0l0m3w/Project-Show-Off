using System;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerInfo : MonoBehaviour
{
    //[SerializeField] private SOTrigger soTrigger;
    private float _distance;
    public Animator anim;

    private void Start()
    {
        _distance = this.transform.position.y;
    }

    private void Update()
    {
        if (GameManager.Instance.face.transform.position.y <= _distance)
        {
            try
            {
                Debug.Log("start Anim");
                anim.Play("BatFlight");
            }
            catch
            {
                Console.WriteLine("No animation linked");
                throw;
            }
            //todo: make sure that the elevator can stop from here without linking more stuff
        }
    }
}