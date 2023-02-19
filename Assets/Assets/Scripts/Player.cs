using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private float _speed = 3.0f;
    // [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigid; 
    private bool _resetJump = false; 

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovement();

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            PlayerJump();
            StartCoroutine(ResetJumpRoutine());
        }    
    }

    private void PlayerMovement()
    {
        // GetAxisRaw gives us only -1, 0 and 1
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(horizontalMove * _speed, _rigid.velocity.y);
    }

    private void PlayerJump()
    {
        _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
    }

    bool IsGrounded()
    {
        // Vector2 origin, Vector2 direction, float distance, int layerMask
        // We can use layer value or bit operator.
        // RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer.value);
        // The << operator shifts its left-hand operand left by the number of bits defined by its right-hand operand.        

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        // Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

        if(hitInfo.collider != null)
        {
            if(_resetJump == false)
            {
                //Debug.Log("Hit: " + hitInfo.collider.name);
                return true;   
            }                     
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
