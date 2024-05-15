using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private XRKnob _xrKnob;
    [SerializeField] private MovingCube platform;
    private float value;
    
    // Start is called before the first frame update
    void Start()
    {
        SetValue();
    }


    private void OnGUI()
    {
        GUI.Label(new Rect(new Vector2(0,0), new Vector2(200, 200)), "The value is: " + value);
    }



    public void SetValue()
    {
        value = _xrKnob.value;
    }
    
    // Update is called once per frame
    void Update()
    {
        platform.currentState = value;
    }
}
