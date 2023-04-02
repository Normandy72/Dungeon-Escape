using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }        
        
        Movement();       
    }

    void Movement()
    {
        if(_currentTarget == pointA.position)
        {
            _spriteRenderer.flipX = true; 
        }
        else
        {
            _spriteRenderer.flipX = false;
        }

        if(transform.position == pointA.position)
        {            
            _currentTarget = pointB.position;
            _animator.Play("Idle");                       
        }
        else if(transform.position == pointB.position)
        {            
            _currentTarget = pointA.position;
            _animator.Play("Idle");                               
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
