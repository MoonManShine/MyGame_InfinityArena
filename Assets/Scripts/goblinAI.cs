// using System.Numerics;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class goblinAI : MonoBehaviour
{
    [SerializeField] private float separationRadius = 1.0f;
    [SerializeField] private float pushForce = 0.5f;
    [SerializeField] private int damage = 10;
    private NavMeshAgent _agent;
    private Rigidbody _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();

        _rb.isKinematic = true;
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

        ApplySeparation();
    }

    void ApplySeparation()
    {
        Collider[] nearby = Physics.OverlapSphere(transform.position, separationRadius);

        foreach (var col in nearby)
        {
            if (col.CompareTag("Goblin") && col.transform != transform)
            {
                Vector3 direction = (transform.position - col.transform.position).normalized;
                transform.position += direction * pushForce * Time.deltaTime;
            }
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
