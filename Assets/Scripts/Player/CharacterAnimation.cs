using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public const string MOVEMENT = "Movement";
    public const string PUNCH1 = "Punch1";
    public const string PUNCH2 = "Punch2";
    public const string PUNCH3 = "Punch3";
    public const string KICK1 = "Kick1";
    public const string KICK2 = "Kick2";
    public const string DEATH = "Death";
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Walk(bool move)
    {
        animator.SetBool(MOVEMENT, move);

    }
    public void Punch1()
    {
        animator.SetTrigger(PUNCH1);
    }
    public void Punch2()
    {
        animator.SetTrigger(PUNCH2);
    }
    public void Punch3()
    {
        animator.SetTrigger(PUNCH3);
    }
    public void Kick1()
    {
        animator.SetTrigger(KICK1);
    }
    public void Kick2()
    {
        animator.SetTrigger(KICK2);
    }
    public void Death()
    {
        animator.SetTrigger(DEATH);
    }
}
