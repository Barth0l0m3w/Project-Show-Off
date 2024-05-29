using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public Animator anim;
    
    private void Start()
    {
        Debug.Log("subscribing BatTrigger");
        GameEvents.current.OnBatTriggerEnter += BatTrigger;
    }
    
    private void BatTrigger()
    {
        PlayAnimation(2);
        Debug.Log("play 1st anim from this player");
    }

    private void PlayAnimation(int animIndex)
    {
        anim.SetInteger("States", animIndex);
    }

    private void OnDestroy()
    {
        GameEvents.current.OnBatTriggerEnter -= BatTrigger;
    }
}
