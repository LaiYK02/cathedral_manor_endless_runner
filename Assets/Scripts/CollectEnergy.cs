using UnityEngine;

public class CollectEnergy : MonoBehaviour
{
    [SerializeField] AudioSource gemFX;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gemFX.Play();
            MasterInfo.energyCount += 1;
            if(MasterInfo.energyCount > 5)
            {
                MasterInfo.energyCount = 5;
            }
            this.gameObject.SetActive(false);
        }
    }
}
