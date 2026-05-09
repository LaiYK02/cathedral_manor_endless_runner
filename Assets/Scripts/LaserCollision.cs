using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    [SerializeField] AudioSource[] disappearFX;

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Coin") && !other.CompareTag("Battery") && !other.CompareTag("Player"))
        {
            GhostDeath ghost = other.GetComponentInParent<GhostDeath>();

            if (ghost != null)
            {
                int FXNum = Random.Range(0, disappearFX.Length);
                if (disappearFX[FXNum].clip != null)
                {
                    AudioSource.PlayClipAtPoint(disappearFX[FXNum].clip, transform.position);
                }

                MasterInfo.coinCount += 50;
                MasterInfo.ghostCount += 1;

                ghost.Die(transform.forward);
            }

            Destroy(this.gameObject);
        }
    }
}