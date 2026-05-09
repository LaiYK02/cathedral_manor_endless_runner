using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
       {
            coinFX.Play();
            MasterInfo.coinCount += 1;
            this.gameObject.SetActive(false);
        }
    }
}
