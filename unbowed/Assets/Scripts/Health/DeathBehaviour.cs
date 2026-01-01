using System.Collections;
using UnityEngine;

public abstract class DeathBehaviour : MonoBehaviour
{
    public abstract IEnumerator DeathEffect();
}
