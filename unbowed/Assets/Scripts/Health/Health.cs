using UnityEngine;
using Mirror;
using System.Collections;

public class Health : NetworkBehaviour
{

    [SyncVar]
    public float maxHealth;
    public DeathBehaviour[] deathBehaviours;

    [HideInInspector]
    [SyncVar]
    public float curHealth;

    void Start()
    {
        if (!isServer)
        {
            enabled = false;
            return;
        }

        curHealth = maxHealth;

        StartCoroutine(DeathRoutine());
    }

    IEnumerator DeathRoutine()
    {
        yield return new WaitUntil(()=>curHealth<=0);
        yield return DeathEffects();
        Die();
    }

    IEnumerator DeathEffects()
    {
        foreach (DeathBehaviour deathBehaviour in deathBehaviours)
        {
            yield return deathBehaviour.DeathEffect();
        }
    }

    void Die()
    {
        NetworkServer.Destroy(gameObject);
    }
}
