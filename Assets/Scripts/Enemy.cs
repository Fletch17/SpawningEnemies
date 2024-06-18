using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Vector3 _position;

    public void SetDestination(Vector3 position)
    {
        _position = position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.deltaTime);
    }
}
