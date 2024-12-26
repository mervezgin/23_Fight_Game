using UnityEngine;
public enum ComboState
{
    None,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2
}
public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnimation;
    private ComboState currentComboState;
    private bool activateTimerToReset;
    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;
    private void Awake()
    {
        playerAnimation = GetComponentInChildren<CharacterAnimation>();
    }
    private void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.None;
    }
    private void Update()
    {
        ComboAttack();
        ResetComboState();
    }
    private void ComboAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentComboState == ComboState.PUNCH3 || currentComboState == ComboState.KICK1 || currentComboState == ComboState.KICK2) return;
            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            if (currentComboState == ComboState.PUNCH1)
            {
                playerAnimation.Punch1();
            }
            if (currentComboState == ComboState.PUNCH2)
            {
                playerAnimation.Punch2();
            }
            if (currentComboState == ComboState.PUNCH3)
            {
                playerAnimation.Punch3();
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentComboState == ComboState.KICK2 || currentComboState == ComboState.PUNCH3) return;
            if (currentComboState == ComboState.None || currentComboState == ComboState.PUNCH1 || currentComboState == ComboState.PUNCH2)
            {
                currentComboState = ComboState.KICK1;
            }
            else if (currentComboState == ComboState.KICK1)
            {
                currentComboState++;
                Debug.Log(currentComboState);
            }
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.KICK1)
            {
                playerAnimation.Kick1();
            }
            if (currentComboState == ComboState.KICK2)
            {
                playerAnimation.Kick2();
            }
        }
    }
    private void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;
            if (currentComboTimer <= 0f)
            {
                currentComboState = ComboState.None;
                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}
