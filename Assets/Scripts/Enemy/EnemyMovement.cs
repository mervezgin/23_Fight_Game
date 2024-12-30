using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public const string PLAYER = "Player";
    private CharacterAnimation enemyAnimation;
    private Rigidbody enemyRb;
    private Transform playerTarget;
    private float enemySpeed = 1.8f;
    private float attackDistance = 1.3f;
    private float chasePlayerAfterAttack = 1.0f;
    private float currentAttackTime;
    private float defaultAttackTime = 2.0f;
    private bool followPlayer, attackPlayer;
    private void Awake()
    {
        enemyAnimation = GetComponentInChildren<CharacterAnimation>();
        enemyRb = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(PLAYER).transform;
    }
    private void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
    }
    private void Update()
    {
        Attack();
    }
    private void FixedUpdate()
    {
        FollowTarget();
    }
    private void FollowTarget()
    {
        if (!followPlayer) return;
        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            transform.LookAt(playerTarget);
            enemyRb.linearVelocity = transform.forward * enemySpeed;
            if (enemyRb.linearVelocity.sqrMagnitude != 0)
            {
                enemyAnimation.Walk(true);
            }
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            enemyRb.linearVelocity = Vector3.zero;
            enemyAnimation.Walk(false);
            followPlayer = false;
            attackPlayer = true;
        }
    }
    private void Attack()
    {
        if (!attackPlayer) return;
        currentAttackTime += Time.deltaTime;
        if (currentAttackTime > defaultAttackTime)
        {
            enemyAnimation.EnemyAttack(Random.Range(0, 3));
            currentAttackTime = 0f;
        }
        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
