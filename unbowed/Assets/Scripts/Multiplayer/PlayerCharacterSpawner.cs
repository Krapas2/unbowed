using UnityEngine;
using Mirror;
using System.Collections;

public class PlayerCharacterSpawner : NetworkBehaviour
{
    public float spawnTime;
    public NetworkIdentity playerObjectPrefab;

    [HideInInspector]
    [SyncVar]
    public NetworkIdentity playerObjectSpawned;

    public override void OnStartServer()
    {
        Spawn();
        StartCoroutine(SpawnRoutine());
    }

    // TODO: randomly selected spawn positions
    void Spawn()
    {
        NetworkIdentity playerObjectSpawning = Instantiate(playerObjectPrefab);
        NetworkServer.Spawn(playerObjectSpawning.gameObject, connectionToClient);
        playerObjectSpawned = playerObjectSpawning;
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitUntil(()=>!playerObjectSpawned);
        yield return new WaitForSeconds(spawnTime);

        Spawn();

        StartCoroutine(SpawnRoutine());
    }
}
