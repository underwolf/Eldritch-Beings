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
        GetComponent<ChargeAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void SlashAttack()
    {
        GetComponent<SlashAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void LeapAttack()
    {
        GetComponent<LeapAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void ProjectileAttack()
    {
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
