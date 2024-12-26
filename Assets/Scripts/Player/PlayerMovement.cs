using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
    private CharacterAnimation playerAnimation;
    private Rigidbody rb;
    private float walkSpeed = 3f;
    private float zSpeed = 1.5f;
    private float rotationY = -90f;
    private float rotationSpeed = 15f;

    private void Awake()
    {
        playerAnimation = GetComponentInChildren<CharacterAnimation>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }
    private void FixedUpdate()
    {
        DetectMovement();
    }
    private void DetectMovement()
    {
        rb.linearVelocity = new Vector3(Input.GetAxisRaw(HORIZONTAL) * (-walkSpeed), rb.linearVelocity.y, Input.GetAxisRaw(VERTICAL) * (-zSpeed));
    }
    private void RotatePlayer()
    {
        if (Input.GetAxisRaw(HORIZONTAL) > 0)
        {
            transform.rotation = Quaternion.Euler(0, -Mathf.Abs(rotationY), 0);
        }
        else if (Input.GetAxisRaw(HORIZONTAL) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0);
        }
    }
    private void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(HORIZONTAL) != 0 || Input.GetAxisRaw(VERTICAL) != 0)
        {
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }
    }
}
