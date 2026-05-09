using UnityEngine;

public class CollectableRotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 100f;

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }
}