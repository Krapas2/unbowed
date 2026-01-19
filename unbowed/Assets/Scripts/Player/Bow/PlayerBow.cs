using UnityEngine;
using Mirror;
using System.Collections;

public class PlayerBow : NetworkBehaviour
{
    public PlayerArrow arrowPrefab;
    public Transform arrowOriginAxis;
    public Transform arrowOrigin;
    [SyncVar]
    public float damage;
    public float minSpeed;
    public float maxSpeed;
    [SyncVar]
    public float chargeTime;
    public float overchargeTime;
    public float overchargeSpread;
    public float chargeSlowdown;

    private float initialPlayerWalkSpeed;
    private float initialPlayerAirAcceleration;


    private PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        initialPlayerWalkSpeed = playerMovement.walkSpeed;
        initialPlayerAirAcceleration = playerMovement.airAcceleration;
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
        AimBehaviour();
        ChargeBehaviour();
    }

    void AimBehaviour()
    {
        if (Camera.main == null)
        {
            return;
        }

        arrowOriginAxis.rotation = Camera.main.transform.rotation;
    }

    void ChargeBehaviour()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ChargeRoutine());
        }
    }

    IEnumerator ChargeRoutine()
    {
        float charge = 0;

        playerMovement.walkSpeed = initialPlayerWalkSpeed * chargeSlowdown;
        playerMovement.airAcceleration = initialPlayerAirAcceleration * chargeSlowdown;
        while (Input.GetButton("Fire1"))
        {
            charge += Time.deltaTime;
            yield return null;
        }
        playerMovement.walkSpeed = initialPlayerWalkSpeed;
        playerMovement.airAcceleration = initialPlayerAirAcceleration;
        Shoot(charge, ShotRotation(charge));
    }

    [Command]
    void Shoot(float charge, Quaternion rotation)
    {
        PlayerArrow spawningArrow = Instantiate(arrowPrefab, arrowOrigin.position, rotation);
        NetworkServer.Spawn(spawningArrow.gameObject);
        spawningArrow.speed = Mathf.Lerp(minSpeed, maxSpeed, charge/chargeTime);
        spawningArrow.damage = damage;
        spawningArrow.owner = gameObject;
    }

    Quaternion ShotRotation(float charge)
    {
        Quaternion spread = charge >= chargeTime + overchargeTime ? 
            Quaternion.Euler(
                Random.Range(-overchargeSpread, overchargeSpread), 
                Random.Range(-overchargeSpread, overchargeSpread), 
                0f) :
            Quaternion.identity;
        return arrowOrigin.rotation * spread;
    }
}
