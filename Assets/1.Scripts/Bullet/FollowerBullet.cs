using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerBullet : Bullet
{
    [SerializeField] private Transform tempParent;
    
    public override void Initialize()
    {
        bd.damage = 10;
        bd.speed = 5f;
        

        transform.SetParent(tempParent);

    }

    public override void Move()
    {
        transform.Translate(new Vector2(0f, Time.deltaTime * bd.speed));

        if (transform.position.y > 7f)
        {
            RemoveBullet();
        }
    }

    public override void RemoveBullet()
    {
        Destroy(gameObject);
    }

    public override void SetTempParent(Transform trans)
    {
        tempParent = trans;
    }
   

   
    void Update() => Move();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            //float damage = transform.parent.GetComponent<MyBullet>().Damage;
            collision.GetComponent<Enemy>().Damage(bd.damage);
            Destroy(gameObject);

        }
    }
}
