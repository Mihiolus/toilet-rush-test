using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private string _levelPrefix = "Level ";

    public void Load()
    {
        SceneManager.LoadScene($"{_levelPrefix}{_levelNumber}");
    }

    private void Start()
    {
        int lastLevel = PlayerPrefs.GetInt("last level unlocked", 1);
        if (lastLevel < _levelNumber)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
