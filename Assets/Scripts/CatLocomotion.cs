using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatLocomotion : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;

    [Header("Detection Layers")]
    [SerializeField] LayerMask groundLayer;

    private float moveSpeed;
    private float x;

    private CharacterController catController;

    private void Awake()
    {
        catController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();

        Debug.Log(IsGrounded());

    }


    private void HandleInput()
    {
        x = Input.GetAxis("Horizontal");
        
        if(Input.GetButtonDown("Sprint Key"))
        {
            moveSpeed = sprintSpeed;
        }

        else if (Input.GetButtonUp("Sprint Key"))
        {
            moveSpeed = walkSpeed;
        }
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = new Vector3(x , 0, 0);
        
        Debug.Log(moveDirection);

        catController.Move(moveDirection * Time.deltaTime * moveSpeed);
    }

    private bool IsGrounded()
    {
       return Physics.CheckSphere(transform.position, 0.4f, groundLayer);
    }

    private void HandleJump()
    {

    }

    private void HandleGravity()
    {

    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.4f);
    }


}
