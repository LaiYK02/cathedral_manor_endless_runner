using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LaserGun : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject player;

    [SerializeField] Slider energyBar;
    [SerializeField] Slider energyBarFullCharged;
    public static bool isEmpty;

    private void Awake()
    {
        isEmpty = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            AttemptShoot();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touch.tapCount == 2)
            {
                AttemptShoot();
            }
        }
    }

    void AttemptShoot()
    {
        if (MasterInfo.energyCount == 5)
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        MasterInfo.energyCount = 0;

        Vector3 spawnPos = player.transform.position + (Vector3.up * 1.5f) + (player.transform.forward * 1f);
        GameObject newLaser = Instantiate(laser, spawnPos, player.transform.rotation);

        if (newLaser.GetComponent<LaserBehavior>() != null)
        {
            newLaser.GetComponent<LaserBehavior>().enabled = true;
        }

        energyBar.gameObject.SetActive(true);
        energyBarFullCharged.gameObject.SetActive(false);
        StartCoroutine(EnergyEmptyAnim());
    }

    IEnumerator EnergyEmptyAnim()
    {
        isEmpty = true;

        float startValue = energyBar.value;
        float targetValue = 0;
        float duration = 0.5f;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            energyBar.value = Mathf.Lerp(startValue, targetValue, t);
            yield return null;
        }

        energyBar.value = 0;
        isEmpty = false;
    }
}