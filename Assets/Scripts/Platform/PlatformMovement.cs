using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformMovement : MonoBehaviour
{
    //private Bats bats;

    [SerializeField] private GameObject bats;
    [SerializeField] private GameObject face;
    [SerializeField] private float speed;

    private Vector3 _position;
    private Vector3 _acceleration;

    public Vector3 offsetToPlayer;

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
            Vector3 pos = face.transform.position + offsetToPlayer;
            Vector3 direction = (face.transform.position - pos).normalized; //angle towards player
            
            Destroy(other.gameObject);
            
            _acceleration.y = 0;

            Instantiate(bats, pos, Quaternion.LookRotation(direction));
            
            
        }
    }
}