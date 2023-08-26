using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController playerCC;
    [SerializeField] float speed = 50f, rotationSpeed = 100f;
    [SerializeField] float jumpForce = 6f, gravity = 20f;
    Vector3 move;

    void Start()
    {
        playerCC = GetComponent<CharacterController>(); 
    }

    
    void Update()
    {
        MovePlayer();
        RotationPlayer();



    }

    private void MovePlayer()
    {

        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        if (Input.GetButton("Jump"))
        {
            move.y = jumpForce;
            print("Pulei");
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
}
