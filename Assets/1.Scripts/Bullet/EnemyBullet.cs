using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private Transform tempParent;

    private Transform player = null;


    public override void Initialize()
    {
        bd.damage = 1;
        bd.delay = 1f;
        bd.speed = 3f;
        bd.tempParent = tempParent;
        
        bd.posParent = transform;

        if (GameObject.FindGameObjectWithTag("Player") == null)
            return;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        Vector2 vec = transform.position - player.position;
        // Mathf.Red2Deg = 360 / (P1 * 2)
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.SetParent(tempParent);
    }

    public void SetTempParent(Transform trans)
    {
        tempParent = trans;
    }

    public override void Move()
    {
        transform.Translate(new Vector2(0f, Time.deltaTime * (bd.speed * -1)));

        if(transform.position.y < -10f)
        {
            RemoveBullet();
        }


    }

    public override void RemoveBullet()
    {
        Destroy(gameObject);
    }



    void Update() => Move();

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            collision.GetComponent<Player>().Die();
        }
    }


}
