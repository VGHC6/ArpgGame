using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevation_exit : MonoBehaviour
{
    
    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryCollision;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //检查
        if (!(other.gameObject.tag == "Player")) { Debug.Log("2"); return; }

        foreach (Collider2D mountain in mountainColliders)
        {

            mountain.enabled = true;
        }

        foreach (Collider2D mountain in boundaryCollision)
        {
            Debug.Log(mountain.name);
            mountain.enabled = false;
        }


        other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;//将玩家的渲染层级设置为1，使其显示在山脉前面
    }
}
