using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatLocomotion : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravitySpeed;

    [Header("Detection Layers")]
    [SerializeField] LayerMask groundLayer;


    private Vector3 playerVelocity;
    private CharacterController catController;
    private InputManager inputManager;

    private float moveSpeed;
    private float horizontalInput;
    
    private bool isSprinting;


    private void Awake() 
    {
        catController = GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
        moveSpeed = walkSpeed;
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
        HandleJump();
        HandleGravity();

        Debug.Log(IsGrounded());
    }


    private void HandleInput()
    {
        horizontalInput = inputManager.GetMovementAxis().x;

        if(Input.GetButtonDown("Sprint Key"))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

    }

    private void HandleMovement()
    {
        Vector2 move = new Vector2(horizontalInput, 0);
        catController.Move(move * Time.deltaTime * moveSpeed);

        if (move != Vector2.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    private bool IsGrounded()
    {
       return Physics.CheckSphere(transform.position, 0.3f, groundLayer);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravitySpeed);
        }
    }

    private void HandleGravity()
    {
        playerVelocity.y += gravitySpeed * Time.deltaTime;
        catController.Move(playerVelocity * Time.deltaTime);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.4f);
    }


}
