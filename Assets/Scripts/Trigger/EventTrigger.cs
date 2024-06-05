using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public Animator anim;
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