using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    public GameObject gameOver;
    public string nomeDoMenuInicial;

    public string nomeDaProximaFase;

    public float timeToLoadScene;
    public float timeToLoadNewScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            VoltarAoMenu();
        }
    }

    private void VoltarAoMenu()
    {
        SceneManager.LoadScene(nomeDoMenuInicial);
    }

    public void GameOverMenu()
    {
        gameOver.SetActive(true);
        EndGameOver();
    }

    public void EndGameOver()
    {
        LoadSceneCR();
    }

    public void LoadSceneCR()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(timeToLoadScene);
        gameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextSceneCR()
    {
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(timeToLoadNewScene);
        SceneManager.LoadScene(nomeDaProximaFase);
    }
}
