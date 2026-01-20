using UnityEngine;
using Mirror;

public class PlayerSliderStats : NetworkBehaviour
{
    [Header("Health")]
    public Health playerHealth;
    public float healthMin;
    public float healthMax;
    [Header("Movement")]
    public PlayerMovement playerMovement;
    public float speedMin;
    public float speedMax;
    public float glideMin;
    public float glideMax;
    [Header("Bow")]
    public PlayerBow playerBow;
    public float damageMin;
    public float damageMax;
    public float chargeMin;
    public float chargeMax;

    private StatsSliders statsSliders;

    void Start()
    {
        statsSliders = StatsSliders.Instance;
        
        if (statsSliders == null)
        {
            Debug.LogError("StatsSliders.Instance is null!");
            return;
        }

        if (!isOwned)
        {
            enabled = false;
            return;
        }

        AssignValues(
            statsSliders.healthSlider.value,
            statsSliders.speedSlider.value,
            statsSliders.damageSlider.value,
            statsSliders.chargeSlider.value
        );
    }

    [Command]
    void AssignValues(
        float healthValue,
        float speedValue,
        float damageValue,
        float chargeValue)
    {
        float summedValues = healthValue + speedValue + damageValue + chargeValue;
        bool valuesAreInvalid = summedValues > statsSliders.maxPoints;
        if (valuesAreInvalid)
        {
            connectionToClient.Disconnect();
            return;
        }
        AssingHealth(healthValue);
        AssingMovement(speedValue);
        AssingBow(damageValue, chargeValue);
    }

    [Server]
    void AssingHealth(float healthValue)
    {
        playerHealth.maxHealth = Mathf.Lerp(healthMin, healthMax, healthValue);
        playerHealth.curHealth = playerHealth.maxHealth;
    }

    [Server]
    void AssingMovement(float speedValue)
    {
        playerMovement.walkSpeed = Mathf.Lerp(speedMin, speedMax, speedValue);
        playerMovement.airAcceleration = Mathf.Lerp(glideMin, glideMax, statsSliders.speedSlider.value);
    }

    [Server]
    void AssingBow(float damageValue, float chargeValue)
    {
        playerBow.damage = Mathf.Lerp(damageMin, damageMax, damageValue);
        playerBow.chargeTime = Mathf.Lerp(chargeMin, chargeMax, chargeValue);
        playerBow.CacheInitialMovementValues();
    }
}
