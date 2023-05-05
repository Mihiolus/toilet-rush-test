using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private int _numberOfPathRequired, _numberOfPathsCreated;
    private PathMover[] _pathMovers;

    // Start is called before the first frame update
    void Start()
    {
        _numberOfPathRequired = 0;
        _numberOfPathsCreated = 0;
        foreach (var pathCreator in FindObjectsOfType<PathCreator>())
        {
            pathCreator.OnNewPathCreated += RegisterPath;
            _numberOfPathRequired++;
        }
        _pathMovers = FindObjectsOfType<PathMover>();
        foreach (var pathMover in _pathMovers)
        {
            pathMover.OnCollision += ProcessCollision;
        }
    }

    private void ProcessCollision()
    {
        foreach (var pathmover in _pathMovers)
        {
            pathmover.Moving = false;
        }
        MenuManager.Instance.ShowDefeat();
    }

    private void RegisterPath(IEnumerable<Vector3> enumerable)
    {
        _numberOfPathsCreated++;
        if (_numberOfPathRequired == _numberOfPathsCreated)
        {
            foreach (var pathMover in _pathMovers)
            {
                pathMover.Moving = true;
            }
        }
    }
}
