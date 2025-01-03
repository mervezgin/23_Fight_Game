using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    private float timer = 2.0f;
    private void Start()
    {
        Invoke("DeactivateAfterTime", timer);
    }
    private void DeactivateAfterTime()
    {
        gameObject.SetActive(false);
    }
}
