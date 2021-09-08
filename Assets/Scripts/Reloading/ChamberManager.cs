using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberManager : MonoBehaviour
{
    public GameObject[] chambers;
    public bool[] chambersEmpty;
    public GameObject bulletBack,bulletBackused,reloader;
    public int activeChamber;



    private void Start()
    {
        chambersEmpty = new bool[6];
        for (int i = 0; i <6; i++)
        {
            chambersEmpty[i] = true;
        }
    }

    public void AddBulletToChamber(int chamberName)
    {
        if (chambers[chamberName].transform.childCount>0)
        {
            Destroy(chambers[chamberName].transform.GetChild(0).gameObject);
        }
        var bullet=Instantiate(bulletBack, chambers[chamberName].transform.position, Quaternion.identity);
        bullet.transform.parent = chambers[chamberName].transform;
        chambersEmpty[chamberName] = false;
    }

    public bool CheckChamberEmpty(int chamberNumber)
    {
         return chambersEmpty[chamberNumber];
    }

    public bool FiredChamber()
    {
        Debug.Log("chamber" + chambers[activeChamber].name);

        switch (activeChamber)
        {
            case 0:
                reloader.transform.localEulerAngles = new Vector3(0f, 0f, 56f);
                return fireChamber();
            case 1:
                reloader.transform.localEulerAngles= new Vector3(0f, 0f, 112f);
                return fireChamber();
            case 2:
                reloader.transform.localEulerAngles = new Vector3(0f, 0f, 173.06f);
                return fireChamber();
            case 3:
                reloader.transform.localEulerAngles = new Vector3(0f, 0f, 234.53f);
                return fireChamber();
            case 4:
                reloader.transform.localEulerAngles = new Vector3(0f, 0f, 292.42f);
                return fireChamber();
            case 5:
                reloader.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                if (CheckChamberEmpty(activeChamber))
                {
                    activeChamber=0;
                    return false;
                }
                else
                {
                    Destroy(chambers[activeChamber].transform.GetChild(0).gameObject);
                    var bulletUsed = Instantiate(bulletBackused, chambers[activeChamber].transform.position, Quaternion.identity);
                    bulletUsed.transform.parent = chambers[activeChamber].transform;
                    chambersEmpty[activeChamber] = true;
                    activeChamber=0;
                    return true;
                }
            default:
                return false;
        }
    }

    bool fireChamber()
    {
        if (CheckChamberEmpty(activeChamber))
        {
            activeChamber++;
            return false;
        }
        else
        {
            Destroy(chambers[activeChamber].transform.GetChild(0).gameObject);
            var bulletUsed = Instantiate(bulletBackused, chambers[activeChamber].transform.position, Quaternion.identity);
            bulletUsed.transform.parent = chambers[activeChamber].transform;
            chambersEmpty[activeChamber] = true;
            activeChamber++;
            return true;
        }

    }
}
