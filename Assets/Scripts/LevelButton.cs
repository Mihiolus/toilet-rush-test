using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _sceneIndex, _levelNumber;

    public void Load()
    {
        SceneManager.LoadScene(_sceneIndex);
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
