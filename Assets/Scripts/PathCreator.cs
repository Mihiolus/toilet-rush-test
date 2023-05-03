using System;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    private LineRenderer _renderer;
    private List<Vector3> _points = new List<Vector3>();
    [SerializeField]
    private float _minPointInterval = 1f;
    public Action<IEnumerable<Vector3>> OnNewPathCreated = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _points.Clear();
        }

        if (Input.GetButton("Fire1"))
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 0f;
            if (IsNewPointAllowed(point))
            {
                _points.Add(point);

                _renderer.positionCount = _points.Count;
                _renderer.SetPositions(_points.ToArray());
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            OnNewPathCreated(_points);
        }
    }

    private bool IsNewPointAllowed(Vector3 point)
    {
        return _points.Count == 0 || Vector3.Distance(_points[_points.Count - 1], point) > _minPointInterval;
    }
}
