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
        GetComponent<FireballHorizontalAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void VerticalAttack()
    {
        GetComponent<FireballVerticalAttack>().Attack();
        Task.current.Succeed();
    }

    [Task]
    public void RadialAttack()
    {
        if (GetComponent<FinalBossHealthManager>().health >= 50)
            projectileAmount = 20;
        if (GetComponent<FinalBossHealthManager>().health <= 50)
            projectileAmount = 70;

        GetComponent<FireballRadialAttack>().Attack(projectileAmount);
        Task.current.Succeed();
    }
}
