using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenuScript : MonoBehaviour
{
    public static string PlayerName;
    public GameObject TheCanvas;
    public GameObject MainMenuPanel;
    public GameObject ExitPanel; 
    public static MainMenuScript instance;
    string MainMenuScene = "Main Menu";
    string FreePlayScene = "Level One";
    string LevelSelectScene = "Level Select";
    string TimedGameScene = "Level One Timed";
    string ScoreBoardScene = "ScoreBoard";
    string OptionsScene = "Options";
     
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayerName = "";
        DontDestroyOnLoad(gameObject);
        MainMenuPanel.SetActive(true);
        ExitPanel.SetActive(false);
    }
    void Update()
    {
        PlayerPrefs.SetString("Name", PlayerName);
    }
    void OnGUI()
    {
        PlayerName = GUI.TextField(new Rect(10, 20, 145, 20), PlayerName, 25);
    }
    public void StartFreePlay()
    {
        MainMenuPanel.SetActive(false);
        ExitPanel.SetActive(true);
        SceneManager.LoadScene(FreePlayScene);
    }
    public void StartLevelSelect()
    {
        MainMenuPanel.SetActive(false);
        ExitPanel.SetActive(true);
        SceneManager.LoadScene(LevelSelectScene);
    }
    public void StartTimedGame()
    {
        MainMenuPanel.SetActive(false);
        ExitPanel.SetActive(true);
        SceneManager.LoadScene(TimedGameScene);
    }
    public void OpenScoreBoard()
    {
        MainMenuPanel.SetActive(false);
        ExitPanel.SetActive(true);
        SceneManager.LoadScene(ScoreBoardScene);
    }
    public void OpenOptions()
    {
        MainMenuPanel.SetActive(false);
        ExitPanel.SetActive(true);
        SceneManager.LoadScene(OptionsScene);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void EndGame()
    {
        ExitPanel.SetActive(true);
        SceneManager.LoadScene(MainMenuScene);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (MainMenuScene == scene.name)
        {
            Debug.Log("It's the MainMenu!");
            MainMenuPanel.SetActive(true);
            ExitPanel.SetActive(false);
        }
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }
}