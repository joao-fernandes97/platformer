using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public string sceneName;

    public void CarregarJogo()
    {
        SceneManager.LoadScene(sceneName);
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

    public void SairDoJogo()
    {
        Application.Quit();
    }
    
}
