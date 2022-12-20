using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;

    void Update()
    {
        scoreTxt.text = $"Score: {GameController.Instance.score}";
    }

}
