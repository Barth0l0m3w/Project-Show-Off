using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bats : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody _rigidbody;

    // Start is called before the first frame update
    private GameObject bat;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Vector3 startpos = this.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Destroy")
        {
            Debug.Log("WALL");
            Destroy(this.gameObject);
        }
    }
}