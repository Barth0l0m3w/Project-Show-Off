using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 _acceleration;

    // Start is called before the first frame update
    void Start()
    {
        _acceleration.y -= speed;
        GameEvents.current.OnBatTriggerEnter += TriggerEnter;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _acceleration;
    }

    private void TriggerEnter()
    {
        Stop();
        Debug.Log("elevator stoppped");
    }

    public void Stop()
    {
        _acceleration.y = 0;
    }

    public void SpeedUp()
    {
        _acceleration.y -= speed;
    }
    
    private void OnDestroy()
    {
        GameEvents.current.OnBatTriggerEnter -= TriggerEnter;
    }
}