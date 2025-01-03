using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public const string LEFTHAND = "LeftHand";
    public const string RIGHTHAND = "RightHand";
    public const string LEFTLEG = "LeftLeg";
    public const string RIGHTLEG = "RightLeg";
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private GameObject hitFxPrefab;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float damage = 2f;
    [SerializeField] private bool isPlayer, isEnemy;
    private void Update()
    {
        DetectCollision();
    }
    private void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        if (hit.Length > 0)
        {
            if (isPlayer)
            {
                Vector3 hitFxPos = hit[0].transform.position;
                hitFxPos.y += 1.3f;
                if (hit[0].transform.forward.x > 0)
                {
                    hitFxPos.x += 0.3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    hitFxPos.x -= 0.3f;
                }
                Instantiate(hitFxPrefab, hitFxPos, Quaternion.identity);
                if (gameObject.CompareTag(LEFTHAND) || gameObject.CompareTag(LEFTLEG))
                {
                    hit[0].GetComponent<Health>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<Health>().ApplyDamage(damage, false);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
