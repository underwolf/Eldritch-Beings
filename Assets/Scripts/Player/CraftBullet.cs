using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBullet : MonoBehaviour
{

    public GameObject bullet;
    public Transform BulletPos;
    private Vector3 bulletNewPos;
    public float timeToCraft = 40.0f;
    public float amountCrafted = 2.0f;
    float startTime,progress;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            startTime = Time.time;
            Debug.Log("started Crafting");
            if(GameObject.Find("BulletOriginalPos").transform.childCount >= 10)
            {
                GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().showWarning = true;
            }
            else
            {
                GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().fillBar = true;
            }

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (startTime + timeToCraft >= Time.time && GameObject.Find("BulletOriginalPos").transform.childCount<=10)
            {
                Debug.Log("Crafted");
                bulletNewPos = new Vector3(BulletPos.position.x, BulletPos.position.y, 0);
                var bulletParent = Instantiate(bullet, bulletNewPos, Quaternion.identity);
                bulletParent.transform.parent = BulletPos;
            }
            GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().fillBar = false;
        }
    }


}
