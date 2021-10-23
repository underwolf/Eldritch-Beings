using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticCultistPuzzleManager : MonoBehaviour
{
    public GameObject[] slidingObstacles;
    private bool canActivate;

    private void Start()
    {
        canActivate = true;
    }

    private void Update()
    {

        if (canActivate)
        {
            canActivate = false;

            int a, b, c;

            a = Random.Range(0, 3);
            b = Random.Range(3, 6);
            c = Random.Range(6, 8);

            StartCoroutine(ActivateObstacles(a, b, c));
        }
    }

    private IEnumerator ActivateObstacles(int a, int b, int c)
    {
        slidingObstacles[a].GetComponent<SlidingObstacle>().SlideAction();
        slidingObstacles[b].GetComponent<SlidingObstacle>().SlideAction();
        slidingObstacles[c].GetComponent<SlidingObstacle>().SlideAction();

        yield return new WaitForSeconds(1.0f);

        canActivate = true;
    }
}
