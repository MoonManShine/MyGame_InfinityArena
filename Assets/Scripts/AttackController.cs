using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Animator attackAnimator;
    [SerializeField] private GameObject swordHitox;

    private bool _isAttack;

    public bool IsAttack { get => _isAttack; }

    public void FinishAttack()
    {
        _isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                _isAttack = true;
                attackAnimator.SetTrigger("IsAttack");
        }
    }
}
