using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public CharacterController2D controller;
    public PlayerAnimation _playerAnim;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
	
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
       if (Input.GetButtonDown("Jump"))
        { 
            jump = true;
        }
        _playerAnim.Move(horizontalMove);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        if (controller.m_Grounded == true)
            _playerAnim.Jump(false);
        else
            _playerAnim.Jump(true);
    }
}
