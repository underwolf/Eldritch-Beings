using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CraftBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform BulletPos;
    private Vector3 bulletNewPos;
    public float timeToCraft;
    public float amountCrafted = 2.0f;
    private float finishCrafting=0;
    float startTime,progress;
    bool filledBar = false;
    public bool infiniteAmmo = true;
    // Update is called once per frame

    private void Start()
    {
        BulletPos = GameObject.FindGameObjectWithTag("BulletPos").transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (infiniteAmmo)
            {
                for (int i = 0; i < 30; i++)
                {
                    GenerateBullet();
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
                GenerateBullet();
                startTime = 0;
                Debug.Log("CRAFTED BULLET");
                FindObjectOfType<FMODFire>().FMODCRAFT();
            }
            GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().fillBar = false;
            GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().hideCraft();
            filledBar = false;
        }
    }

    public void ForceCraft()
    {
        GenerateBullet();
        startTime = 0;
        GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().fillBar = false;
        GameObject.Find("CraftingCanvas").GetComponent<ProgressBar>().hideCraft();
        filledBar = true;
        Debug.Log("CRAFTED BULLET");
        FindObjectOfType<FMODFire>().FMODCRAFT();
    }


    public void GenerateBullet()
    {
        bulletNewPos = new Vector3(BulletPos.position.x, BulletPos.position.y, BulletPos.position.z);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
        var bulletParent = Instantiate(bullet, bulletNewPos, spawnRotation);
        bulletParent.transform.parent = BulletPos;
        bulletParent.transform.localScale = new Vector3(1.5f, 1.5f, 0);
    }



}
