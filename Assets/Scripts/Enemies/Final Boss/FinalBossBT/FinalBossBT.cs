using System.Collections;
using System.Collections.Generic;
using Panda;
using UnityEngine;

[RequireComponent(typeof(PandaBehaviour))]
public class FinalBossBT : MonoBehaviour
{
    public int projectileAmount;

    [Task]
    public void HorizontalAttack()
    {
        GetComponent<EnemiesCultist>().SetDamageType(EnemiesCultist.DamageType.Circle);
        GetComponent<FireballHorizontalAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void VerticalAttack()
    {
        GetComponent<EnemiesCultist>().SetDamageType(EnemiesCultist.DamageType.Star);
        GetComponent<FireballVerticalAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void RadialAttack()
    {
        if (GetComponent<HealthManager>().health >= 50)
            projectileAmount = 20;
        if (GetComponent<HealthManager>().health <= 50)
            projectileAmount = 70;

        GetComponent<EnemiesCultist>().SetDamageType(EnemiesCultist.DamageType.Triangle);
        GetComponent<FireballRadialAttack>().Attack(projectileAmount);
        Task.current.Succeed();
    }
}
