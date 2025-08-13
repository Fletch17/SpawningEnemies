using System;
using System.Drawing;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _mainPoint;
    [SerializeField] private float _speed = 5.5f;
    [SerializeField] private float _deltaPosition = 0.5f;

    private int _currentPoint;
    private Transform[] _points;
    private Vector3 _targetPosition;
    private Vector3 _gameObjectPosition;

    private void Awake()
    {
        Transform [] allChildren = _mainPoint.GetComponentsInChildren<Transform>();

        _points = new Transform[allChildren.Length-1];
        Array.Copy(allChildren, 1, _points, 0, _points.Length);
        _currentPoint = 0;
    }

    private void Update()
    {
        _targetPosition = _points[_currentPoint].transform.position;
        _targetPosition.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        _gameObjectPosition = new Vector3(transform.position.x, 0, transform.position.z);
        _targetPosition = new Vector3(_points[_currentPoint].transform.position.x, 0, _points[_currentPoint].transform.position.z);             

        if (Vector3.Distance(_gameObjectPosition, _targetPosition) <= _deltaPosition)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
