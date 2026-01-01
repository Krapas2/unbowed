using UnityEngine;
using Mirror;

public class PlayerArrow : NetworkBehaviour
{
    public float damage;
    public float speed;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (!isServer)
        {
            enabled = false;
            return;
        }

        rb.linearVelocity = transform.forward * speed;
    }

    void Update()
    {
        transform.forward = rb.linearVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isServer)
        {
            return;
        }

        if(other.TryGetComponent<Health>(out Health otherHealth))
        {
            otherHealth.curHealth -= damage * rb.linearVelocity.magnitude;
        }

        NetworkServer.Destroy(gameObject);
    }
}
