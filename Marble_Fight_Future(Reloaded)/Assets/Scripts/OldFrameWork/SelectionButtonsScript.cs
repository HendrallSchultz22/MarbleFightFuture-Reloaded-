using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionButtonsScript : MonoBehaviour
{
    string MainMenuScene = "Main Menu";
    string LevelOneScene = "Level One";
    string LevelOneTimedScene = "Level One Timed";
    string LevelTwoScene = "Level Two";
    string LevelTwoTimedScene = "Level Two Timed";
    string LevelThreeScene = "Level Three";
    string LevelThreeTimedScene = "Level Three Timed";
    string LevelFourScene = "Level Four";
    string LevelFourTimedScene = "Level Four Timed";
    string LevelFiveScene = "Level Five";
    string LevelFiveTimedScene = "Level Five Timed";
    public void SelectionLevelOne()
    {
        SceneManager.LoadScene(LevelOneScene);
    }
    public void SelectionLevelOneTImed()
    {
        SceneManager.LoadScene(LevelOneTimedScene);
    }
    public void SelectionLevelTwo()
    {
        SceneManager.LoadScene(LevelTwoScene);
    }
    public void SelectionLevelTwoTimed()
    {
        SceneManager.LoadScene(LevelTwoTimedScene);
    }
    public void SelectionLevelThree()
    {
        SceneManager.LoadScene(LevelThreeScene);
    }
    public void SelectionLevelThreeTimed()
    {
        SceneManager.LoadScene(LevelThreeTimedScene);
    }
    public void SelectionLevelFour()
    {
        SceneManager.LoadScene(LevelFourScene);
    }
    public void SelectionLevelFourTimed()
    {
        SceneManager.LoadScene(LevelFourTimedScene);
    }
    public void SelectionLevelFive()
    {
        SceneManager.LoadScene(LevelFiveScene);
    }
    public void SelectionLevelFiveTimed()
    {
        SceneManager.LoadScene(LevelFiveTimedScene);
    }
    public void ExitSelection()
    {
        SceneManager.LoadScene(MainMenuScene);
    }
}