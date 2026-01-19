using UnityEngine;
using Mirror;
using System.Collections;

public class PlayerArrow : NetworkBehaviour
{
    public float damage;
    public float speed;
    public LayerMask ignore;
    public float ignoreOwnerTime;

    [HideInInspector]
    public GameObject owner;

    private bool ignoringOwner;
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
        StartCoroutine(IgnoreOwnerRoutine());
    }

    IEnumerator IgnoreOwnerRoutine()
    {
        ignoringOwner = true;
        yield return new WaitForSeconds(ignoreOwnerTime);
        ignoringOwner = false;
    }

    void Update()
    {
        transform.forward = rb.linearVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        bool isInIgnoredLayer = ignore.Includes(other.gameObject);
        bool isOwnerIgnored = ignoringOwner && other.gameObject == owner;
        if (!isServer || isInIgnoredLayer || isOwnerIgnored)
        {
            return;
        }

        if(other.TryGetComponent<Health>(out Health otherHealth))
        {
            HealthInteraction(otherHealth);
        }

        NetworkServer.Destroy(gameObject);
    }

    void HealthInteraction(Health otherHealth)
    {
        otherHealth.curHealth -= damage * rb.linearVelocity.magnitude;
    }
}
