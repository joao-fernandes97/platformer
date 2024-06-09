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
    public string firstLevel;
    public string secondLevel;
    public string secondTutorial;

    public float timeToLoadScene;
    public float timeToLoadNewScene;

    public int KeyCounter { get; private set; } = 0;

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
        if(KeyCounter == 1)
            StartCoroutine(NextScene());   
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(timeToLoadNewScene);
        SceneManager.LoadScene(nomeDaProximaFase);
    }

    public void FirstLevelCR()
    {
        StartCoroutine(FirstScene());
    }

    private IEnumerator FirstScene()
    {
        yield return new WaitForSeconds(timeToLoadNewScene);
        SceneManager.LoadScene(firstLevel);
    }

    public void SecondLevelCR()
    {
        StartCoroutine(SecondScene());
    }

    private IEnumerator SecondScene()
    {
        yield return new WaitForSeconds(timeToLoadNewScene);
        SceneManager.LoadScene(secondLevel);
    }

    public void SecondTutorialCR()
    {
        StartCoroutine(SecondTutorial());
    }

    private IEnumerator SecondTutorial()
    {
        yield return new WaitForSeconds(timeToLoadNewScene);
        SceneManager.LoadScene(secondTutorial);
    }

    public void IncreaseKeyCounter()
    {
        KeyCounter = 0;
        KeyCounter ++;
    }
}
