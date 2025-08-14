using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 2f;

    private SpawnPoint[] _spawnPoints;

    public void Spawn(int index)
    {
        SpawnPoint spawnPoint = _spawnPoints[index];

        Instantiate(spawnPoint.EnemyPrefab, spawnPoint.Position, Quaternion.identity).SetDestination(spawnPoint.DestinationPoint);
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
