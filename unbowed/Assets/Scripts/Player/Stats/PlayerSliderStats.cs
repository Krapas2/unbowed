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
        if (!isOwned)
        {
            enabled = false;
            return;
        }

        statsSliders = StatsSliders.Instance;
        
        if (statsSliders == null)
        {
            Debug.LogError("StatsSliders.Instance is null!");
            return;
        }

        AssingHealth();
        AssingMovement();
        AssingBow();
    }

    void AssingHealth()
    {
        playerHealth.maxHealth = Mathf.Lerp(healthMin, healthMax, statsSliders.healthSlider.value);
    }

    void AssingMovement()
    {
        playerMovement.walkSpeed = Mathf.Lerp(speedMin, speedMax, statsSliders.speedSlider.value);
        playerMovement.airAcceleration = Mathf.Lerp(glideMin, glideMax, statsSliders.speedSlider.value);
    }

    void AssingBow()
    {
        playerBow.damage = Mathf.Lerp(damageMin, damageMax, statsSliders.damageSlider.value);
        playerBow.chargeTime = Mathf.Lerp(chargeMin, chargeMax, statsSliders.chargeSlider.value);
    }
}
