using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnimator;
    private Animator _swordAnimator;
    void Start()
    {
        _playerAnimator = GetComponentInChildren<Animator>();
        //_playerAnimator = transform.GetChild(0).GetComponent<Animator>();
        _swordAnimator = transform.GetChild(1).GetComponent<Animator>();
        
    }

    public void Move(float move)
    {
        _playerAnimator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _playerAnimator.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _playerAnimator.SetTrigger("Attack");
        _swordAnimator.SetTrigger("SwordAnimation");
    }
}
