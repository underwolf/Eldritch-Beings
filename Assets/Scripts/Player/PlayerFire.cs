using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public GameObject aimObj;
    private GameObject firepoint;
    public GameObject bulletPrefab;
    public LineRenderer lineRenderer;

    bool canfire = false;
    // Update is called once per frame
    void Update()
    {
        if(aimObj.activeInHierarchy && Input.GetButtonDown("Fire1"))
        {
            firepoint = GameObject.FindGameObjectWithTag("FIREPOINT");
            StartCoroutine(Shoot());
        }
    }

    //RAYCAST SHOOTING
    IEnumerator Shoot()
    {
        canfire=GameObject.Find("ChamberManager").GetComponent<ChamberManager>().FiredChamber();
        if (canfire)
        {
            RaycastHit2D hit = Physics2D.Raycast(firepoint.transform.position, firepoint.transform.right);
            if (hit)
            {
                Debug.Log(hit.transform.name);
                lineRenderer.SetPosition(0, firepoint.transform.position);
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                lineRenderer.SetPosition(0, firepoint.transform.position);
                lineRenderer.SetPosition(1, firepoint.transform.position + firepoint.transform.right * 100);
            }
            lineRenderer.enabled = true;
            Instantiate(bulletPrefab, firepoint.transform.position, firepoint.transform.rotation);
            yield return 0;
            lineRenderer.enabled = false;
        }
        else
        {
            //click click
        }

    }

}
