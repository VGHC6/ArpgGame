using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevation : MonoBehaviour
{
    //关闭山脉碰撞器
    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryCollision;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //检查
       if (!(other.gameObject.tag == "Player")) { Debug.Log("2"); return; }

        foreach (Collider2D mountain in mountainColliders)
        {
            
            mountain.enabled = false;
        }

        foreach (Collider2D mountain in boundaryCollision)
        {
            Debug.Log(mountain.name);
            mountain.enabled = true;
        }


        other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;//将玩家的渲染层级设置为1，使其显示在山脉前面
    }
}
