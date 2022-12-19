using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    void Awake() => Instance = this;

    public int Iife = 3;
    public float power = 1f;
    public int score = 0;
    public bool leftSub = false;
    public bool rightSub = false;
  
}
