using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController playerCC;
    [SerializeField] float speed = 50f;
    [SerializeField] float rotationSpeed = 100f;
    float moveX, moveY, rotationY;
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
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        move = new Vector3(moveX, 0, moveY);
        move = transform.TransformDirection(move);

        playerCC.Move(move * Time.deltaTime * speed);
    }

    private void RotationPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rotationY = Input.GetAxis("Mouse X");

        transform.Rotate(rotationY * Vector3.up * Time.deltaTime * rotationSpeed);

    }
}
