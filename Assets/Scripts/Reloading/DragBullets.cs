using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBullets : MonoBehaviour
{
    public GameObject bulletPos;

    private float startPosX, startPosY;
    private bool isBeingHeld = false;
    private Vector3 originalPos;

    private bool isOnChamber = false;
    private Vector3 chamberTransform;
    private string chamberName;
    private int chamberNumber;

    private void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x-startPosX, mousePos.y-startPosY, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.transform.parent = null;
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;
            isBeingHeld = true;
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }

    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
        if (isOnChamber == false)
        {
            bulletPos = GameObject.Find("BulletOriginalPos");
            originalPos = bulletPos.transform.position;
            this.transform.position = originalPos;
            this.gameObject.transform.parent= bulletPos.transform;

        }
        else
        {
            if (GameObject.Find("ChamberManager").GetComponent<ChamberManager>().CheckChamberEmpty(chamberNumber))
            {
                GameObject.Find("ChamberManager").GetComponent<ChamberManager>().AddBulletToChamber(chamberNumber);

                Destroy(this.gameObject);
            }
            else
            {
                bulletPos = GameObject.Find("BulletOriginalPos");
                originalPos = bulletPos.transform.position;
                this.transform.position = originalPos;
                this.gameObject.transform.parent = bulletPos.transform;
            }
           
        }
        this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Debug.Log("Entrou");
            isOnChamber = true;
            chamberTransform = collision.gameObject.transform.position;
            chamberName = collision.gameObject.name;
            switch (chamberName)
            {
                case "C1":
                    chamberNumber = 0;
                    break;
                case "C2":
                    chamberNumber = 1;
                    break;
                case "C3":
                    chamberNumber = 2;
                    break;
                case "C4":
                    chamberNumber = 3;
                    break;
                case "C5":
                    chamberNumber = 4;
                    break;
                case "C6":
                    chamberNumber = 5;
                    break;
                default:
                    Debug.Log("Chamber Doesnt Exist");
                    break;
            }
            Debug.Log($"Chamber name: {chamberName}");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bulletPos = GameObject.Find("BulletOriginalPos");
        originalPos = bulletPos.transform.position;
        isOnChamber = false;
        chamberTransform = originalPos;
        chamberName = collision.gameObject.name;
    }
}
