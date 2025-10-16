using UnityEngine;
using UnityEngine.AI;

public class goblinAI : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private Transform player;
    private NavMeshAgent _agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (player == null)
            player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            _agent.SetDestination(player.position);
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
