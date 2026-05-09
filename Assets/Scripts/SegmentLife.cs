using UnityEngine;

public class SegmentLife : MonoBehaviour
{
    private Transform playerTransform;

    private float destroyDistance = 60f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (transform.position.z < playerTransform.position.z - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}