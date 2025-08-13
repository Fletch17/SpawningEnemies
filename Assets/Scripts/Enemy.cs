using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Transform _transform;
    private Vector3 _targetPosition;

    public void SetDestination(Transform gameObject)
    {
        _transform = gameObject;
    }

    private void Update()
    {
        _targetPosition = _transform.position;
        _targetPosition.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}
