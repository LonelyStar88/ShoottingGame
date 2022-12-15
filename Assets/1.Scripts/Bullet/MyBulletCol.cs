using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBulletCol : MonoBehaviour
{
    float damage = 0;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            //collision.GetComponent<Enemy>().Damage(damage);
            GameObject.FindWithTag("Player")
                .GetComponent<MyBullet>()
                .RemoveBullet(gameObject);
        }
    }
}
