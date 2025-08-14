using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 5f;

    private Transform _targetTransform;
    private Vector3 _targetPosition;

    public void SetDestination(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }

    private void Start()
    {
        StartCoroutine(MoveAndRotate());
    }

    private IEnumerator MoveAndRotate()
    {
        while (enabled)
        {
            _targetPosition = _targetTransform.position;
            _targetPosition.y = transform.position.y;
            Vector3 direction = (_targetPosition - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.SetPositionAndRotation(Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime), Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed));
            yield return null;
        }
    }
}
