using System.Collections;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public const string LEFTHAND = "LeftHand";
    public const string LEFTLEG = "LeftLeg";
    public const string UNTAGGED = "Untagged";
    public const string ENEMY = "Enemy";
    public const string MAINCAMERA = "MainCamera";
    private CharacterAnimation characterAnimation;
    private AudioSource audioSource;
    private EnemyMovement enemyMovement;
    private ShakeCamera shakeCamera;
    [SerializeField] private AudioClip whooshSound, fallSound, groundHitSound, deadSound;
    [SerializeField] private GameObject leftHandAttackPoint;
    [SerializeField] private GameObject rightHandAttackPoint;
    [SerializeField] private GameObject leftLegAttackPoint;
    [SerializeField] private GameObject rightLegAttackPoint;
    [SerializeField] private float standUpTimer = 2.0f;
    private void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();
        if (gameObject.CompareTag(ENEMY))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();
        }
        shakeCamera = GameObject.FindWithTag(MAINCAMERA).GetComponent<ShakeCamera>();
    }
    private void LeftHandAttackOn()
    {
        leftHandAttackPoint.SetActive(true);
    }
    private void LeftHandAttackOff()
    {
        if (leftHandAttackPoint.activeInHierarchy)
        {
            leftHandAttackPoint.SetActive(false);
        }
    }
    private void RightHandAttackOn()
    {
        rightHandAttackPoint.SetActive(true);
    }
    private void RightHandAttackOff()
    {
        if (rightHandAttackPoint.activeInHierarchy)
        {
            rightHandAttackPoint.SetActive(false);
        }
    }
    private void LeftLegAttackOn()
    {
        leftLegAttackPoint.SetActive(true);
    }
    private void LeftLegAttackOff()
    {
        if (leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }
    private void RightLegAttackOn()
    {
        rightLegAttackPoint.SetActive(true);
    }
    private void RightLegAttackOff()
    {
        if (rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }
    private void TagLeftHand()
    {
        leftHandAttackPoint.tag = LEFTHAND;
    }
    private void UnTagLeftHand()
    {
        leftHandAttackPoint.tag = UNTAGGED;
    }
    private void TagLeftLeg()
    {
        leftLegAttackPoint.tag = LEFTLEG;
    }
    private void UnTagLeftLeg()
    {
        leftLegAttackPoint.tag = UNTAGGED;
    }
    private void EnemyStandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }
    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTimer);
        characterAnimation.StandUp();
    }
    private void AttackFxSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whooshSound;
        audioSource.Play();
    }
    private void CharacterDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = deadSound;
        audioSource.Play();
    }
    private void EnemyKnockDown()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }
    private void EnemyHitGround()
    {
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }
    private void DisableMovemenet()
    {
        enemyMovement.enabled = false;
        transform.parent.gameObject.layer = 0;
    }
    private void EnableMovement()
    {
        enemyMovement.enabled = true;
        transform.parent.gameObject.layer = 10;
        Debug.Log(transform.parent.gameObject.layer);
        Debug.Log(transform.parent.gameObject.name);
    }
    private void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }
}
