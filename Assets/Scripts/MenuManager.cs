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

    public void ShowVictory()
    {
        _victoryScreen.SetActive(true);
    }

    public void ShowDefeat()
    {
        _defeatScreen.SetActive(true);
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
