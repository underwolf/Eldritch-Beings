using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCultist : MonoBehaviour
{
    public Transform firepoint;
    public GameObject[] bulletsPrefabs;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var activeBullet = FindObjectOfType<ChangeWeaponCultist>().GetWeaponActive();
        Instantiate(bulletsPrefabs[activeBullet],firepoint.position,firepoint.rotation);
    }
}
