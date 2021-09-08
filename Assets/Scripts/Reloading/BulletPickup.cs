using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour
{
    public GameObject bullet;
    public Transform BulletPos;
    private Vector3 bulletNewPos;
    private bool pickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickedUp)
        {
            return;
        }
        if (collision.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            bulletNewPos = new Vector3(BulletPos.position.x, BulletPos.position.y, 0);
            var bulletParent = Instantiate(bullet, bulletNewPos, Quaternion.identity);
            bulletParent.transform.parent = BulletPos;
            Destroy(gameObject);
            pickedUp = true;
        }

    }


}
