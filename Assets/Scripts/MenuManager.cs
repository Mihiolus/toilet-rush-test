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
    [SerializeField] private string _levelPrefix = "Level ", _titleScene = "Title";
    [SerializeField] private int _nextLevel;

    public void ShowVictory()
    {
        _victoryScreen.SetActive(true);
        if (_nextLevel > 0)
        {
            PlayerPrefs.SetInt("last level unlocked", _nextLevel);
        }
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
        SceneManager.LoadScene($"{_levelPrefix}{_nextLevel}");
    }

    public void GoBackToTitle()
    {
        SceneManager.LoadScene(_titleScene);
    }
}
