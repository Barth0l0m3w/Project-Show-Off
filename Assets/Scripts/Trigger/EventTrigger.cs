using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public Animator anim;
    
    private void Start()
    {
        //Debug.Log("subscribing AnimTrigger");
        GameEvents.current.OnAnimTriggerEnter += AnimTrigger;
    }
    
    private void AnimTrigger()
    {
        if(anim == null) return;
        PlayAnimation(2);
        GameManager.Instance.TriggerHaptics(0.7f, anim.GetCurrentAnimatorClipInfo(0).Length);
        Debug.Log("play 1st anim from this player");
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
