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
    [SerializeField] private Transform _character, _destination;
    private bool _drawing = false;

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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit && hit.transform == _character)
            {
                _drawing = true;
                _points.Clear();
            }
        }

        if (Input.GetButton("Fire1") && _drawing)
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

        if (Input.GetButtonUp("Fire1") && _drawing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit && hit.transform == _destination)
            {
                _drawing = false;
                _points[0] = _character.position;
                //turn off script to disable redrawing
                enabled = false;
                OnNewPathCreated(_points);
            }
            else
            {
                _points.Clear();
                _renderer.positionCount = 0;
            }
            _drawing = false;
        }
    }

    private bool IsNewPointAllowed(Vector3 point)
    {
        return _points.Count == 0 || Vector3.Distance(_points[_points.Count - 1], point) > _minPointInterval;
    }
}
