using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnRadius = 20f;
    [SerializeField] private float spawnInterval = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnGoblin), 2f, spawnInterval);
    }
    
    void SpawnGoblin()
    {
        Vector3 randomPos = player.position + Random.insideUnitSphere * spawnRadius;
        randomPos.y = player.position.y + 5f;

        if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, 10f, NavMesh.AllAreas))
        {
            Instantiate(goblinPrefab, hit.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Couldnt find a spot");
        }
    }
}
