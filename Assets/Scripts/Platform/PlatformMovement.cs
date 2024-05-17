using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PlatformMovement : MonoBehaviour
{
    //private Bats bats;

    [SerializeField] private GameObject bats;
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject face;

    [SerializeField] private float speed;

    private Vector3 _acceleration;

    public Vector3 batsOffset;
    public Vector3 rockOffset;

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

    public void TypeTrigger(string type)
    {
        if (type == "Bats")
        {
            Debug.Log("release the bats");
            Vector3 posBat = face.transform.position + batsOffset;
            Vector3 direction = (face.transform.position - posBat).normalized;

            Instantiate(bats, posBat, Quaternion.LookRotation(direction));
        } else if (type == "Rock")
        {
            Debug.Log("watch out for your head");
            Vector3 posRock = face.transform.position + rockOffset;
            Instantiate(rock, posRock, Quaternion.identity);
        }
    }

    public void Stop()
    {
        _acceleration.y = 0;
    }

    public void SpeedUp()
    {
        _acceleration.y -= speed;
    }
}