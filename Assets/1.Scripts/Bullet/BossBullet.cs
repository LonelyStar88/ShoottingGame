using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Bullet
{
    private Transform tempParent;
    public override void Initialize()
    {
        bd.damage = 1;
        bd.delay = 1f;
        bd.speed = 3f;
        bd.posParent = transform;
    }

    void Update() => Move();
  
    public override void Move()
    {
        transform.Translate(new Vector2(0f, Time.deltaTime * (bd.speed * -1)));
        if (transform.position.y < -20f || transform.position.y > 20f || transform.position.x < -20f || transform.position.x > 20f)
        {
            RemoveBullet();
        }

    }

    public override void SetTempParent(Transform trans)
    {
        tempParent = trans;
    }

    public override void RemoveBullet()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            collision.GetComponent<Player>().Die();
            RemoveBullet();
        }
        
    }
}
    
   

