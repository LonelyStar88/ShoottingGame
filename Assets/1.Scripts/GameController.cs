using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePlayType
{
    Play,
    Pause,
    Stop
}
public class GameController : MonoBehaviour
{
    public EnemyController enemyCont;
    public static GameController Instance;

    void Awake() => Instance = this;

    public GamePlayType playtype = GamePlayType.Play;

    public int Life { get; set; }
    public float power { get; set; }
    public int Score { get; set; }

    public const int BossSpawn = 3;

    public int stage { get; set; }
    float time = 0;
    //public int boom = 3;

    void Start()
    {
        Life = 3;
        power = 1;
        Score = 0;
        stage = 0;
    }
    void Update()
    {
        if (stage % BossSpawn == 0)
            return;

        time += Time.deltaTime;
        if(time > 10)
        {
            time = 0;
            stage++;
        }
    }

}
