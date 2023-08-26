using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController playerCC;
    Animator playerAnimator;
    [SerializeField] float speed = 10f, rotationSpeed = 100f;
    [SerializeField] float jumpForce = 10f, gravity = 5f;
    Vector3 move;

    void Start()
    {
        playerCC = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        MovePlayer();
        RotationPlayer();
        AnimationPlayer();


    }

    private void MovePlayer()
    {

        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        if (Input.GetButton("Jump"))
        {
            move.y = jumpForce;
        }
        move.y -= gravity;

        move = transform.TransformDirection(move);
        playerCC.Move(move * Time.deltaTime * speed);
    }

    private void RotationPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;

        transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * Time.deltaTime * rotationSpeed);

    }

    private void AnimationPlayer()
    {
        if(playerCC.velocity.x != 0f && playerCC.velocity.z != 0f)
        {
            playerAnimator.SetBool("isWalk", true);
        }
        else playerAnimator.SetBool("isWalk", false);

        playerAnimator.SetBool("isJump", !playerCC.isGrounded);
    }
}
