using UnityEngine;
using Mirror;
using System.Collections;

public class PlayerCharacterSpawner : NetworkBehaviour
{
    public float spawnTime;
    public NetworkIdentity playerObjectPrefab;

    [HideInInspector]
    public NetworkIdentity playerObjectSpawned;

    void Start()
    {
        Spawn();
        StartCoroutine(SpawnRoutine());
    }


    // TODO: randomly selected spawn positions
    void Spawn()
    {
        playerObjectSpawned = Instantiate(playerObjectPrefab);
        NetworkServer.Spawn(playerObjectSpawned.gameObject);
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitUntil(()=>!playerObjectSpawned);
        yield return new WaitForSeconds(spawnTime);

        Spawn();

        StartCoroutine(SpawnRoutine());
    }
}
