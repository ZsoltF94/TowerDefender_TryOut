using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // For better movement
    [SerializeField] float acceleration = 5f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float damping = 5f;

    // References
    Vector2 moveInput;
    Rigidbody2D rb;

    // Reference InputSystem
    InputSystem_Actions inputActions;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
    }

    public void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

    }

    public void OnDisable()
    {
        inputActions.Disable();
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = moveInput * maxSpeed;
        Vector2 velocityChange = targetVelocity - rb.linearVelocity;

        rb.AddForce(velocityChange * acceleration, ForceMode2D.Force);
        rb.AddForce(-rb.linearVelocity * damping, ForceMode2D.Force);
    }


}
