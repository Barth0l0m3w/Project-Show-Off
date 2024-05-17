using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PlatformMovement : MonoBehaviour
{
    //private Bats bats;

    
    

    [SerializeField] private float speed;

    private Vector3 _acceleration;

    

    //public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        _acceleration.y -= speed;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _acceleration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "trigger")
        {
            Destroy(other.gameObject);
            Stop();
        }
    }

    /*public void TypeTrigger(string type)
    {
        if (type == "Bats")
        {
            
        } else if (type == "Rock")
        {
            
        }
    }*/

    public void Stop()
    {
        _acceleration.y = 0;
    }

    public void SpeedUp()
    {
        _acceleration.y -= speed;
    }
}