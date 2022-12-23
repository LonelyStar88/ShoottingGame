using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : Bullet
{
    [SerializeField]
    private Transform tempParent;

    

    public float Damage
    {
        get; set;
    }

    public override void Initialize()
    {
        bd.damage = 1;
        bd.delay = 1f;
        bd.speed = 3f;
        bd.tempParent = tempParent;

        transform.SetParent(bd.tempParent);

        
    }
   
    public override void Move()
    {
        transform.Translate(new Vector2(0f, Time.deltaTime * bd.speed));

        if(transform.position.y > 7f)
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
        if(collision.tag.Equals("wall"))
        {
            RemoveBullet();
        }
    }

}
