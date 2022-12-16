using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : Bullet
{
    [SerializeField]
    private Transform tempParent;

    float damage = 0;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public override void Initialize()
    {
        bd.damage = 1;
        bd.delay = 1f;
        bd.speed = 3f;
        bd.tempParent = tempParent;

       
    }

    public override void Move()
    {
        transform.Translate(new Vector2(0f, Time.deltaTime * bd.speed));
    }


    public override void RemoveBullet()
    {
        Destroy(gameObject);
    }

    public void SetTempParent(Transform trans)
    {
        tempParent = trans;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            collision.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
            
        }
    }

    void Update() => Move();
    
}
