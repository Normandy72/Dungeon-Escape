using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _animator.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
