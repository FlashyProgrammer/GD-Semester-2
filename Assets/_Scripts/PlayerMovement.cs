using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls inputs;
    private Vector3 playerDirection;
    private Rigidbody playerRb;
    private bool isMoving;

    [Header("Movement Parameters")]
    [SerializeField] private float moveSpeed = 5f;


    [Header("Ground Parameters")]
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask groundLayer;


    private void Awake()
    {
        inputs = new PlayerControls();
        playerRb = GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }


    private void FixedUpdate()
    {
        if (isMoving)
        {
            Movement();
            
        }
        SpeedControl();
       
     
    }

    private void Movement()
    {
        playerDirection = transform.forward * inputs.Player.Move.ReadValue<Vector3>().z + transform.right * inputs.Player.Move.ReadValue<Vector3>().x;

        // Walking
        if (IsGrounded())
        {
            playerRb.AddForce(playerDirection.normalized * moveSpeed, ForceMode.Force);
        }
        
    }

    private void SpeedControl()
    {
        Vector3 currentVelocity = new Vector3(playerRb.linearVelocity.x, 0f, playerRb.linearVelocity.z);

        if (currentVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = currentVelocity.normalized * moveSpeed;
            playerRb.linearVelocity = new Vector3(limitedVelocity.x, playerRb.linearVelocity.y, limitedVelocity.z);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        bool isGrounded = Physics.Raycast(transform.position, -Vector3.up, out hit, rayDistance, groundLayer);
        Debug.DrawRay(transform.position, -Vector3.up * hit.distance, Color.yellow);

        if (isGrounded)
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    public void CanMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isMoving = true;
          
        }

        if (context.canceled)
        {
            isMoving = false;
         
        }

    }
}
