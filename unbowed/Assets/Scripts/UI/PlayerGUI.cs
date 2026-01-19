using Mirror;
using UnityEngine;

public class PlayerGUI : NetworkBehaviour
{
    public HealthBarGUI healthBarGUI;
    public ChargeBarGUI chargeBarGUI;

    private GameObject playerCharacter;

    void Start()
    {
        NetworkIdentity playerObject = NetworkClient.localPlayer;
        playerCharacter = playerObject.GetComponent<PlayerCharacterSpawner>().playerObjectSpawned.gameObject;
    }

    void Update()
    {
        if (!playerCharacter)
        {
            Destroy(gameObject);
        }
    }
}
