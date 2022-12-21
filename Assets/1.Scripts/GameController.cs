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
    public static GameController Instance;

    void Awake() => Instance = this;

    public GamePlayType playtype = GamePlayType.Play;

    public int Iife = 3;
    public float power = 1f;
    public int score = 0;
    public int boom = 3;
    public bool leftSub = false;
    public bool rightSub = false;
    
  
}
