using UnityEngine;
using UnityEngine.AI;

public class goblinAI : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    private NavMeshAgent _agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance != null)
        {
            _agent.SetDestination(PlayerController.Instance.transform.position);
        }
        else
        {
            Debug.LogWarning("Player not found for goblin: " + gameObject.name);
            _agent.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController hp = other.GetComponent<PlayerController>();
            if (hp != null)
                hp.TakeDamage(damage);
        }
    }
}
