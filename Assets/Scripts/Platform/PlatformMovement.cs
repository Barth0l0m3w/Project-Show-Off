using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformMovement : MonoBehaviour
{
    private Bats bats;
    
    [SerializeField] private float speed;
    private Vector3 position;

    [SerializeField] private Vector3 acceleration;

    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
        acceleration.y -= speed;
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position += acceleration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "trigger")
        {
            Debug.Log("trigger reached");
            Destroy(other.gameObject);
            acceleration.y = 0;
            
            //todo: instansiate bats. 
        }
    }
}