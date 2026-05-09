using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;
    public static int distanceRun;
    [SerializeField] GameObject runDisplay;
    [SerializeField] int internalDistance;

    public static int energyCount = 0;
    [SerializeField] int currentEnergyCount;
    [SerializeField] Slider energyBar;
    private bool isRefill;
    [SerializeField] AudioSource energyFullChargedFX;
    [SerializeField] Slider energyBarFullCharged;

    public static int ghostCount = 0;
    [SerializeField] GameObject ghostDisplay;

    void Awake()
    {
        coinCount = 0;
        distanceRun = 0;
        energyCount = 0;
        energyBar.value = 0;
        isRefill = false;
        ghostCount = 0;
    }

    void Update()
    {
        internalDistance = distanceRun;
        //energyCount = currentEnergyCount;
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "" + coinCount;
        runDisplay.GetComponent<TMPro.TMP_Text>().text = "" + distanceRun;
        ghostDisplay.GetComponent<TMPro.TMP_Text>().text = "" + ghostCount;
        if(!isRefill && !LaserGun.isEmpty)
        {
            if (energyBar.value < energyCount)
            {
                StartCoroutine(EnergyRefillAnim());
            }
        }
    }

    IEnumerator EnergyRefillAnim()
    {
        isRefill = true;
        energyBar.value += 0.1f;
        yield return new WaitForSeconds(0.01f);
        if(energyBar.value == 5)
        {
            energyFullChargedFX.Play();
            energyBar.gameObject.SetActive(false);
            energyBarFullCharged.gameObject.SetActive(true);
        }
        isRefill = false;
    }
}
