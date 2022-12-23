using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text stageTxt;
    void Update()
    {
        scoreTxt.text = $"Score: {GameController.Instance.Score}";
        stageTxt.text = $"Score: {GameController.Instance.stage}";
    }

}
