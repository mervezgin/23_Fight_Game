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
    public const string ATTACK1 = "Attack1";
    public const string ATTACK2 = "Attack2";
    public const string ATTACK3 = "Attack3";
    public const string HIT = "Hit";
    public const string KNOCKDOWN = "KnockDown";
    public const string STANDUP = "StandUp";
    public const string ENEMYDEATH = "EnemyDeath";
    public const string ENEMYIDLE = "EnemyIdle";
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
    public void EnemyAttack(int attack)
    {
        if (attack == 0)
        {
            animator.SetTrigger(ATTACK1);
        }
        if (attack == 1)
        {
            animator.SetTrigger(ATTACK2);
        }
        if (attack == 2)
        {
            animator.SetTrigger(ATTACK3);
        }
    }
    public void PlayIdleAnimation()
    {
        animator.Play(ENEMYIDLE);
    }
    public void KnockDown()
    {
        animator.SetTrigger(KNOCKDOWN);
    }
    public void StanUp()
    {
        animator.SetTrigger(STANDUP);
    }
    public void Hit()
    {
        animator.SetTrigger(HIT);
    }
    public void EnemyDeath()
    {
        animator.SetTrigger(ENEMYDEATH);
    }

}
