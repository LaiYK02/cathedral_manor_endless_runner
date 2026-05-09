using UnityEngine;
using System.Collections;

public class GhostDeath : MonoBehaviour
{
    [Header("Knockback Settings")]
    [SerializeField] Rigidbody mainRigidbody;
    [SerializeField] float knockbackForce = 15f;

    [Header("Fading Settings")]
    [SerializeField] Renderer meshRenderer;
    [SerializeField] float fadeDuration = 2f;

    void Awake()
    {
        // Automatically find components if not assigned
        if (mainRigidbody == null) mainRigidbody = GetComponent<Rigidbody>();
        if (meshRenderer == null) meshRenderer = GetComponentInChildren<Renderer>();
    }

    public void Die(Vector3 hitDirection)
    {
        mainRigidbody.isKinematic = false;
        mainRigidbody.useGravity = true;

        mainRigidbody.AddForce((hitDirection + Vector3.up).normalized * knockbackForce, ForceMode.Impulse);

        StartCoroutine(FadeAndDestroy());
    }

    IEnumerator FadeAndDestroy()
    {
        float elapsedTime = 0;

        Material ghostMat = meshRenderer.material;
        Color startColor = ghostMat.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            Color c = startColor;
            c.a = newAlpha;
            ghostMat.color = c;

            yield return null;
        }

        Destroy(gameObject);
    }
}