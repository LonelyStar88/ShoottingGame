using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemData
{
    public GameObject obj;
    public float speed;
}
public abstract class Item : MonoBehaviour
{
    public ItemData itemData = new ItemData();
    public abstract void Initialize();

    public void Move()
    {
        itemData.obj.transform.Translate(Vector2.down * Time.deltaTime * itemData.speed);
    }

    void Update()
    {
        if (itemData.obj == null)
            return;

        Move();
    }

}
