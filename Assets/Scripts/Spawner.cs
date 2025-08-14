using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 2f;

    private SpawnPoint[] _spawnPoints;

    public void Spawn(int index)
    {
        Instantiate(_spawnPoints[index].EnemyPrefab, _spawnPoints[index].Position, Quaternion.identity).SetDestination(_spawnPoints[index].DestinationPoint);
    }

    private void Awake()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(SpawnInRandomPoint());
    }

    private IEnumerator SpawnInRandomPoint()
    {
        var spawnRate = new WaitForSeconds(_spawnRate);

        while (enabled)
        {
            Spawn(UnityEngine.Random.Range(0, _spawnPoints.Length));
            yield return spawnRate;
        }
    }
}
