using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenuControl : MonoBehaviour
{
    [SerializeField] GameObject coinDisplays1;
    [SerializeField] GameObject runDisplays1;
    [SerializeField] GameObject ghostDisplays1;
    [SerializeField] GameObject energyBar;

    [SerializeField] GameObject restartMenu;
    [SerializeField] GameObject coinDisplay2;
    [SerializeField] GameObject ghostDisplay2;
    [SerializeField] GameObject runDisplay2;

    private void Start()
    {
        coinDisplays1.SetActive(false);
        runDisplays1.SetActive(false);
        ghostDisplays1.SetActive(false);
        energyBar.SetActive(false);

        coinDisplay2.GetComponent<TMPro.TMP_Text>().text = "" + MasterInfo.coinCount;
        ghostDisplay2.GetComponent<TMPro.TMP_Text>().text = "" + MasterInfo.ghostCount;
        runDisplay2.GetComponent<TMPro.TMP_Text>().text = "" + MasterInfo.distanceRun;
        restartMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        MainMenuControl.hasClicked = true;
        SceneManager.LoadScene(0);
    }
}
