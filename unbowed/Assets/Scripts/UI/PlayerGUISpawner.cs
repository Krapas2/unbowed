using UnityEngine;
using Mirror;

public class PlayerGUISpawner : NetworkBehaviour
{
    public Health playerHealth;
    public PlayerBow playerBow;
    public PlayerGUI guiPrefab;

    private PlayerGUI spawnedGui;

    void Start()
    {
        if (!isOwned)
        {
            enabled = false;
            return;
        }

        spawnedGui = Instantiate(guiPrefab);

        AssignComponents();
    }

    void AssignComponents()
    {
        AssignHealthBar();
        AssignChargeBar();
    }

    void AssignHealthBar()
    {
        HealthBarGUI healthBar = spawnedGui.healthBarGUI;
        healthBar.playerHealth = playerHealth;
        healthBar.enabled = true;
    }

    void AssignChargeBar()
    {
        ChargeBarGUI chargeBar = spawnedGui.chargeBarGUI;
        chargeBar.playerBow = playerBow;
        chargeBar.enabled = true;
    }
}
