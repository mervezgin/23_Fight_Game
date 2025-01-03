using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    private CharacterAnimation characterAnimation;
    private EnemyMovement enemyMovement;
    private bool characterDied;
    [SerializeField] private bool isPlayer;
    private void Awake()
    {
        characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }
    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied) return;
        health -= damage;
        if (health <= 0f)
        {
            characterAnimation.Death();
            characterDied = true;
            if (isPlayer)
            {

            }
            return;
        }
        if (!isPlayer)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    characterAnimation.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    characterAnimation.Hit();
                }
            }
        } //if is player
    } //apply damage
} //class
