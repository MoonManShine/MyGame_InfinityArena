using UnityEngine;
using UnityEngine.AI;

public class GoblinAnimation : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetFloat("Speed", _agent.velocity.magnitude);

        // if (CanAttack())
        // {
        //     anim.SetTrigger("Attack");
        // }   
    }
}
