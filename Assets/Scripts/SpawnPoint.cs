using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3 _deltaPosition;

    public Enemy EnemyPrefab { get { return _enemyPrefab; } }
    public Vector3 Position { get { return transform.position + _deltaPosition; } }
    public Transform DestinationPoint { get { return _destinationPoint; } }
}
