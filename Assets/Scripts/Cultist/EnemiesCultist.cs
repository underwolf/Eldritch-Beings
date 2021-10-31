using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemiesCultist : MonoBehaviour
{
    public enum DamageType { Star, Circle, Triangle, InvertedTriangle};
    public DamageType damageType;

    public SpriteRenderer enemyHitType;
    public Sprite[] possibleTypes;

    private void Start()
    {
        damageType = (DamageType)Random.Range(0, 3);
        switch (damageType)
        {
            case DamageType.Star:
                enemyHitType.sprite = possibleTypes[0];
                break;
            case DamageType.Circle:
                enemyHitType.sprite = possibleTypes[1];
                break;
            case DamageType.Triangle:
                enemyHitType.sprite = possibleTypes[2];
                break;
            case DamageType.InvertedTriangle:
                enemyHitType.sprite = possibleTypes[3];
                break;
            default:
                break;
        }
    }


    //USE THIS TO SET THE TYPE
    public void SetDamageType(DamageType type)
    {
        damageType = type;
        switch (type)
        {
            case DamageType.Star:
                enemyHitType.sprite = possibleTypes[0];
                break;
            case DamageType.Circle:
                enemyHitType.sprite = possibleTypes[1];
                break;
            case DamageType.Triangle:
                enemyHitType.sprite = possibleTypes[2];
                break;
            case DamageType.InvertedTriangle:
                enemyHitType.sprite = possibleTypes[3];
                break;
            default:
                break;
        }
    }

    public void SetDamageTypeStar()
    {
        SetDamageType(DamageType.Star);
    }
    public DamageType GetDamageType() {
        return damageType;
    }

}
