using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    [SerializeField]
    private Enemy enemy1;
    // Start is called before the first frame update
    void Start()
    {
        enemy.Initialize();
        enemy1.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.Move();
        enemy1.Move();
    }
}
