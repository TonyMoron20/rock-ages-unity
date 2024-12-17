using UnityEngine;

public class RockVelocity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 1.0f;
        const float MaxImpulseForce = 4.0f;
        float angle = Random.Range(0, 2 * Mathf.PI);

        Vector2 direction = new Vector2 (Mathf.Cos(angle), Mathf.Sin(angle));

        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
