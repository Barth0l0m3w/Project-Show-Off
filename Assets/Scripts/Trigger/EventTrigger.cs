using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int animId;

    private void Start()
    {
        GameEvents.current.OnAnimEnter += Anim;
    }

    private void Anim(int id)
    {
        if (anim != null)
        {
            if (id == animId)
            {
                PlayAnimation(animId);
                Debug.Log("play 1st anim from this player");
            }
        }
        //todo: should we uncomment this?
        //GameManager.Instance.TriggerHaptics(0.7f, anim.GetCurrentAnimatorClipInfo(0).Length);
    }

    private void PlayAnimation(int animIndex)
    {
        anim.SetInteger("States", animIndex);
    }

    private void OnDestroy()
    {
        GameEvents.current.OnAnimEnter -= Anim;
    }
}