using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    public float baseSpeed = 14;
    public float currentSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentSpeed = PlayerMovement.playerSpeed + baseSpeed;

        rb.linearVelocity = transform.forward * currentSpeed;

        Destroy(gameObject, 3f);
    }
}