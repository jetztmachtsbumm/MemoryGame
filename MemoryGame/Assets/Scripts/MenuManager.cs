using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject serverConnectionCanvas;

    public void OnSoloButtonClicked()
    {
        SceneManager.LoadScene("SoloGame");
    }

    public void OnDuellButtonClicked()
    {
        mainMenuCanvas.SetActive(false);
        serverConnectionCanvas.SetActive(true);
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    public void OnConnectButtonClicked()
    {

    }

    public void OnBackButtonClicked()
    {
        mainMenuCanvas.SetActive(true);
        serverConnectionCanvas.SetActive(false);
    }

}
