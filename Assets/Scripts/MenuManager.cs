using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance;
    public static MenuManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<MenuManager>();
            }
            return _instance;
        }
    }

    [SerializeField] private GameObject _victoryScreen, _defeatScreen;
    [SerializeField] private string _nextLevel = "Level 2", _titleScene = "Title";

    public void ShowVictory()
    {
        _victoryScreen.SetActive(true);
    }

    public void ShowDefeat()
    {
        _defeatScreen.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(_nextLevel);
    }

    public void GoBackToTitle(){
        SceneManager.LoadScene(_titleScene);
    }
}
