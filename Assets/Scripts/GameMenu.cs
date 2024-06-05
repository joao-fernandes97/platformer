using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    //public GameObject mainMenu;

    public string sceneName;

    public Animator transitionAnim;

    public GameObject blackScreen;

    void Start()
    {
        ShowBlackScreenCR();
    }

    public void LoadGame()
    {
        blackScreen.SetActive(true);
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(sceneName);
    }

    public void ShowBlackScreenCR()
    {
        StartCoroutine(ShowBlackScreen());
    }

    private IEnumerator ShowBlackScreen()
    {
        blackScreen.SetActive(true);
        transitionAnim.SetTrigger("start");
        yield return new WaitForSeconds(2.0f);
        blackScreen.SetActive(false);
    }

    /*public void AtivarPainelDoMenuInicial()
    {
        mainMenu.SetActive(true);
    }*/

    /*public void AtivarPainelDaTelaDeCreditos()
    {
        mainMenu.SetActive(false);
        //painelDaTelaDeCreditos.SetActive(true);
    }*/

    public void LeaveGame()
    {
        Application.Quit();
    }
    
}
