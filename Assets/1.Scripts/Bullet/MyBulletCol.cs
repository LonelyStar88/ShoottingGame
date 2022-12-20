using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBulletCol : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            float damage = transform.parent.GetComponent<MyBullet>().Damage;
            collision.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
          
        }
    }
}
