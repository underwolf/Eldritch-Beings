using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBullet : MonoBehaviour
{

    public GameObject bullet;
    public Transform BulletPos;
    private Vector3 bulletNewPos;
    public float timeToCraft = 0.3f;
    public float amountCrafted = 2.0f;
    private float finishCrafting=0;
    float startTime,progress;
    bool filledBar = false;
    public bool infiniteAmmo = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (infiniteAmmo)
            {
                for (int i = 0; i < 30; i++)
                {
                    bulletNewPos = new Vector3(BulletPos.position.x, BulletPos.position.y, 0);
                    var bulletParent = Instantiate(bullet, bulletNewPos, Quaternion.identity);
                    bulletParent.transform.parent = BulletPos;
                }
            }
            if(GameObject.Find("BulletOriginalPos").transform.childCount >= 10)
            {
                GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().showWarning = true;
            }
            else
            {
                GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().fillBar = true;
                startTime = Time.deltaTime;
                finishCrafting = startTime + timeToCraft;
            }
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            
            if (Time.deltaTime >= finishCrafting  && GameObject.Find("BulletOriginalPos").transform.childCount<=10 && filledBar==false)
            {
                bulletNewPos = new Vector3(BulletPos.position.x, BulletPos.position.y, 0);
                var bulletParent = Instantiate(bullet, bulletNewPos, Quaternion.identity);
                bulletParent.transform.parent = BulletPos;
                startTime = 0;
            }
            GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().fillBar = false;
            GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().hideCraft();
            filledBar = false;
        }
    }

    public void ForceCraft()
    {
        bulletNewPos = new Vector3(BulletPos.position.x, BulletPos.position.y, 0);
        var bulletParent = Instantiate(bullet, bulletNewPos, Quaternion.identity);
        bulletParent.transform.parent = BulletPos;
        startTime = 0;
        GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().fillBar = false;
        GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().hideCraft();
        filledBar = true;
    }




}
