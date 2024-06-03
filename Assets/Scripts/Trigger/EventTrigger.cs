using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public Animator anim;
    private int _animNumber = 2;

    private void Start()
    {
        GameEvents.current.OnAnimTriggerEnter += AnimTrigger;
    }

    private void AnimTrigger()
    {
        if (anim != null)
        {
            PlayAnimation(_animNumber);
            _animNumber++;
            Debug.Log("play 1st anim from this player");
        }
    }

    private void PlayAnimation(int animIndex)
    {
        anim.SetInteger("States", animIndex);
    }

    private void OnDestroy()
    {
        GameEvents.current.OnAnimTriggerEnter -= AnimTrigger;
    }
}