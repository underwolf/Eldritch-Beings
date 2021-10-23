using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAttack : MonoBehaviour
{
    public GameObject laserStart;
    public GameObject laserMiddle;

    public Transform firePoint;

    private float maxBeamSize = 100f;
    private float currentBeamSize;

    private GameObject beamObjStart, beamObjMiddle;

    public bool testAttack = false;

    /*private void Update()
    {
        if (testAttack)
        {
            testAttack = false;
            Attack();
        }
    }

    public void Attack()
    {
        StartCoroutine(CreateBeam());
    }*/

    //private IEnumerator CreateBeam()
    private void Update()
    {
        //yield return new WaitForSeconds(1f);

        if(beamObjStart == null)
        {
            beamObjStart = Instantiate(laserStart, firePoint.position, Quaternion.identity); 
            beamObjStart.transform.parent = firePoint;
        }

        float startSpriteWidth = beamObjStart.GetComponent<Renderer>().bounds.size.x;

        if(beamObjMiddle == null)
        {
            beamObjMiddle = Instantiate(laserMiddle, firePoint.position, Quaternion.identity);
            beamObjMiddle.transform.parent = firePoint;
        }

        Vector2 beamDirection = firePoint.transform.right;
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, beamDirection, maxBeamSize);

        currentBeamSize = Vector2.Distance(hit.collider.transform.position, firePoint.position);

        beamObjMiddle.transform.localScale = new Vector2(currentBeamSize, beamObjMiddle.transform.localScale.y);
        beamObjMiddle.transform.localPosition = new Vector2((currentBeamSize / 2f), 0f);

        //yield return new WaitForSeconds(3.0f);

        //Destroy(beamObjStart);
        //Destroy(beamObjMiddle);
       
    }
}
