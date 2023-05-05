using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    [SerializeField]
    private PathCreator _pathCreator;
    private List<Vector3> _path;
    private int _nextIndex = -1;
    [SerializeField]
    private float _travelDuration = 2f, _reachDistance = 0.1f;
    private Rigidbody2D _body;
    private float _speed;
    private bool _moving = false;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _pathCreator.OnNewPathCreated += SetPoints;
    }

    private void SetPoints(IEnumerable<Vector3> points)
    {
        _path = new List<Vector3>(points);
        _nextIndex = 0;
        float pathLength = 0f;
        for (int i = 1; i < _path.Count; i++)
        {
            pathLength += Vector3.Distance(_path[i - 1], _path[i]);
        }
        _speed = pathLength / _travelDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasPath() && _moving)
        {
            Vector3 displacement = _path[_nextIndex] - transform.position;
            if (displacement.magnitude <= _reachDistance)
            {
                _nextIndex++;
                return;
            }
            if (displacement.magnitude > _speed * Time.deltaTime)
            {
                displacement = displacement.normalized * _speed * Time.deltaTime;
            }
            transform.Translate(displacement);
        }
    }

    public void StartMoving()
    {
        _moving = true;
    }

    private bool HasPath()
    {
        return _path != null && _nextIndex < _path.Count;
    }
}
