using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform tempParent;

    public bool IsOpen { get; set; }

    public float DelayTime { get; set; }
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("CreateBullet", 1f, DelayTime);
    }

    // Update is called once per frame
    void CreateBullet()
    {
        Bullet bul = Instantiate(bullet, transform);
        bul.SetTempParent(tempParent);
        bul.Initialize();
    }
}
