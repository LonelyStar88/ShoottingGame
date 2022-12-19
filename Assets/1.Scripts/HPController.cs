using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer hpRender;
    
    public void SetRenderSize(float curHP, float maxHP)
    {
        Vector2 size = new Vector2(curHP/maxHP, 1f);
        hpRender.transform.localScale = size;
    }
}
