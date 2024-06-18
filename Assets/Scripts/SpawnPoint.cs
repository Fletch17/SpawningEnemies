using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3 _deltaPosition;

    public void Spawn()
    {
        Instantiate(_enemyPrefab, transform.position + _deltaPosition, Quaternion.identity).SetDestination(_destinationPoint.position);
    }
}
