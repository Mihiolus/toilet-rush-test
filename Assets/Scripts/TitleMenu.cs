using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelSelectText;
    [SerializeField] private int _numberOfLevels;
    [SerializeField] private string _levelPrefix = "Level ";
    [SerializeField] int _lastLevel;

    // Start is called before the first frame update
    void Start()
    {
        _lastLevel = PlayerPrefs.GetInt("last level unlocked", 1);
        _levelSelectText.text = $"{_levelPrefix}{_lastLevel}/{_numberOfLevels}";
    }

    public void Play()
    {
        SceneManager.LoadScene($"{_levelPrefix}{_lastLevel}");
    }
}
