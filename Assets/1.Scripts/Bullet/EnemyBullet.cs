using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    [SerializeField]
    private Transform tempParent;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject prefab;

    private Transform player = null;
    public override void Initialize()
    {
        bd.damage = 1;
        bd.delay = 1f;
        bd.speed = 3f;
        bd.parent = parent;
        bd.prefab = prefab;
        bd.isPlayer = false;
        bd.tempParent = tempParent;
        
        bd.posParent = transform;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SetTempParent(Transform trans)
    {
        tempParent = trans;
    }

    public void SetEnemy(Transform trans)
    {
        parent = trans;
    }

    public override void RemoveBullet(GameObject bullet)
    {
        base.RemoveBullet(bullet);
    }

    void LateUpdate()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        Vector2 vec = transform.position - player.position;
        // Mathf.Red2Deg = 360 / (P1 * 2)
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
    
}
