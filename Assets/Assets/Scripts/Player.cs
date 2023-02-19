using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // GetAxisRaw gives us only -1, 0 and 1
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);
    }
}
