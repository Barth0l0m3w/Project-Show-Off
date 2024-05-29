using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fadeout : MonoBehaviour
{
    public enum FadeType
    {
        FADEIN,
        FADEOUT
    }

    public FadeType _FadeType;
    
    [SerializeField] private CanvasGroup panel;
    [SerializeField] private float fadeIncrement = 0.02f;
    private bool startFadeout;
    private bool startFadein;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            if (_FadeType == FadeType.FADEIN)
            {
                //startFadeout = false;
                startFadein = true;
            }
            else if(_FadeType == FadeType.FADEOUT)
            {
                //startFadein = false;
                startFadeout = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_FadeType == FadeType.FADEIN)
        {
            
            startFadein = false;
        }
        else if(_FadeType == FadeType.FADEOUT)
        {
            
            startFadeout = false;
        }
    }

    private void FixedUpdate()
    {
        if (startFadeout && panel.alpha < 1)
        {
            panel.alpha += fadeIncrement;
        }
        else if (startFadein && panel.alpha > 0)
        {
            panel.alpha -= fadeIncrement;
        }
    }
}
