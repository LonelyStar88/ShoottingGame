using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : Bullet
{
    [SerializeField]
    private Transform tempParent;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject prefab;

    public override void Initialize()
    {
        bd.damage = 1;
        bd.delay = 1f;
        bd.speed = 3f;
        bd.parent = transform;
        bd.prefab = prefab;
        bd.isPlayer = true;
        bd.tempParent = tempParent;
    }
    
    
}
