using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private Vector3 startPosition;
    private float power = 0.2f;
    private float duration = 0.2f;
    private float slowDownAmount = 1f;
    private float initialDuration;
    private bool shouldShake;
    private void Start()
    {
        startPosition = transform.localPosition;
        initialDuration = duration;
    }
    private void Update()
    {
        Shake();
    }
    private void Shake()
    {
        if (shouldShake)
        {
            if (duration > 0f)
            {
                transform.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                transform.localPosition = startPosition;
            }
        }
    }
    public bool ShouldShake
    {
        get { return shouldShake; }
        set { shouldShake = value; }
    }
}
