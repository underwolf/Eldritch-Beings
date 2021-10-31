using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCultistTest : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public enum BulletTypes { Star,Circle,Triangle,InvertedTriangle};
    public BulletTypes bulletType;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        EnemiesCultist enemy = collision.GetComponent<EnemiesCultist>();
        if (enemy != null)
        {
            var type = enemy.GetDamageType();
            var typetoStringEnemy = type.ToString();
            var typetoStringPlayer = bulletType.ToString();
            if(string.Equals(typetoStringEnemy, typetoStringPlayer))
            {
                enemy.GetComponent<HealthManager>().TakeDamage(1);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("N deu dano no bicho");
                Destroy(gameObject);
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
