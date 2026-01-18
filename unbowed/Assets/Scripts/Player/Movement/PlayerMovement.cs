using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [Header("Walking")]
    [SyncVar]
    public float walkSpeed;
    public float walkLerpSpeed;

    [Header("Jumping")]
    public float jumpForce;

    [Header("Air Gliding")]
    [SyncVar]
    public float airAcceleration;
    public float airDamping;

    [Header("Physics Materials")]
    public PhysicsMaterial movingMaterial;
    public PhysicsMaterial standingMaterial;

    [Header("Misc")]
    public Transform groundCheck;
    public float groundCheckDistance;
    public LayerMask groundLayers;

    private bool grounded;
    private Vector3 direction;

    private Rigidbody rb;
    private Collider col;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

	void Start()
	{
        if (!isOwned)
        {
            enabled = false;
            return;
        }
    }

    void Update()
    {
        direction = MovementDirection();
        grounded = Grounded();
        
        SetPhysicsMaterial();
        WalkBehaviour();
        JumpBehaviour();
        AirBehaviour();
    }

    Vector3 MovementDirection()
    {
        return (
            Input.GetAxisRaw("Vertical") * transform.forward.XOZ().normalized +
            Input.GetAxisRaw("Horizontal") * transform.right.XOZ().normalized
        ).normalized;
    }

    void SetPhysicsMaterial()
    {
        col.material = direction.magnitude > 0 ? movingMaterial : standingMaterial;
    }

    bool Grounded()
    {
        return Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayers);
    }

    void WalkBehaviour()
    {
        if (!grounded)
        {
            return;
        }

        Walk();
    }

    void Walk()
    {
        Vector3 desiredHorizontalVelocity = direction * walkSpeed;
        Vector3 currentHorizontalVelocity = rb.linearVelocity.XOZ();

        Vector3 horizontalVelocity = Vector3.Lerp(
            desiredHorizontalVelocity,
            currentHorizontalVelocity,
            Mathf.Pow(.5f, walkLerpSpeed * Time.deltaTime)
        );

        rb.linearVelocity = new Vector3(
            horizontalVelocity.x,
            rb.linearVelocity.y,
            horizontalVelocity.z
        );
    }

    void JumpBehaviour()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void AirBehaviour()
    {
        if (grounded)
        {
            return;
        }

        AirGliding();

        if(direction.magnitude > 0)
        {
            ApplyHorizontalAirDamping();
        }
    }

    void AirGliding()
    {
        Vector3 forceVector = airAcceleration * Time.deltaTime * direction;

        rb.AddForce(forceVector, ForceMode.Impulse);
    }

    void ApplyHorizontalAirDamping()
    {
        Vector3 horizontalVelocity = (1 - airDamping) * Time.deltaTime * rb.linearVelocity.XOZ();

        rb.AddForce(horizontalVelocity, ForceMode.Impulse);
    }

    void OnDrawGizmos()
    {
        DrawGroundCheckGizmo();
    }

    void DrawGroundCheckGizmo()
    {
        if (groundCheck)
        {        
            Gizmos.color = Color.green;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
        }
    }
}
