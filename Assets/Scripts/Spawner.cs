using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 2f;

    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(SpawnInRandomPoint());
    }

    private IEnumerator SpawnInRandomPoint()
    {
        var spawnRate = new WaitForSeconds(_spawnRate);

        while (true)
        {
            _spawnPoints[Random.Range(0, _spawnPoints.Length)].Spawn();
            yield return spawnRate;
        }
    }
}
