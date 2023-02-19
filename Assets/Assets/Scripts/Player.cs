using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private bool _grounded = false;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigid;
    private bool _resetJumpNeeded = false;    

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovement();

        if(Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            PlayerJump();
            _resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
        }

        RaycastHit();      
    }

    private void PlayerMovement()
    {
        // GetAxisRaw gives us only -1, 0 and 1
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(horizontalMove, _rigid.velocity.y);
    }

    private void PlayerJump()
    {
        _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
        _grounded = false;
    }

    private void RaycastHit()
    {
        // Vector2 origin, Vector2 direction, float distance, int layerMask
        // The << operator shifts its left-hand operand left by the number of bits defined by its right-hand operand. 
        // RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

        if(hitInfo.collider != null)
        {
            //Debug.Log("Hit: " + hitInfo.collider.name);

            if(_resetJumpNeeded == false)
            {
                _grounded = true;
            }            
        }
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
    }
}
