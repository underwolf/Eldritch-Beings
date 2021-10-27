using System.Collections;
using System.Collections.Generic;
using Panda;
using UnityEngine;

[RequireComponent(typeof(PandaBehaviour))]
public class MinibossBT : MonoBehaviour
{
    public GameObject projectileSpawner;

    [Task]
    public void ChargeAttack()
    {
        GetComponent<EnemiesCultist>().SetDamageType(EnemiesCultist.DamageType.InvertedTriangle);
        GetComponent<ChargeAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void SlashAttack()
    {
        GetComponent<EnemiesCultist>().SetDamageType(EnemiesCultist.DamageType.Triangle);
        GetComponent<SlashAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void LeapAttack()
    {
        GetComponent<EnemiesCultist>().SetDamageType(EnemiesCultist.DamageType.Circle);
        GetComponent<LeapAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void ProjectileAttack()
    {
        GetComponent<EnemiesCultist>().SetDamageType(EnemiesCultist.DamageType.Star);
        projectileSpawner.GetComponent<ProjectileAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void Die()
    {
        //play death animation
        Destroy(gameObject);
        Task.current.Succeed();
    }

    [Task]
    public bool IsHealthy()
    {
        return GetComponent<FinalBossHealthManager>().isHealthy;
    }

    [Task]
    public void IsDone()
    {
        Debug.Log("NOOO THIS CANOT BEEEEE");
    }

    [Task]
    public void NotDone()
    {
        Debug.Log("Something is wrong...");
    }
}
