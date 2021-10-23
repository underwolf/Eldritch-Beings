using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponCultist : MonoBehaviour
{
    public GameObject[] m_WeaponTypes;
    public int m_weaponActive;
    public void SetCultistWeapon(string weaponType)
    {
        switch (weaponType)
        {
            case "five_point_star":
                Debug.Log("five_point");
                SetWeaponActive(0);
                break;
            case "five point star":
                Debug.Log("five point");
                SetWeaponActive(0);
                break;
            case "Circle":
                SetWeaponActive(1);
                Debug.Log("circle");
                break;
            case "D":
                Debug.Log("D");
                SetWeaponActive(1);
                break;
            case "Triangle":
                SetWeaponActive(2);
                Debug.Log("Triangle");
                break;
            case "InvertedTriangle":
                Debug.Log("InvertedTriangle");
                SetWeaponActive(3);
                break;
            default:
                Debug.Log("default");
                break;
        }
    }
    public void SetWeaponActive(int whatWeaponsIsActive)
    {
        FindObjectOfType<SelectedElementDisplay>().setSprite(whatWeaponsIsActive);
        m_weaponActive = whatWeaponsIsActive;

    }

    public int GetWeaponActive()
    {
        return m_weaponActive;
    }
}
