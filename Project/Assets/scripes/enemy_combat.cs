using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_combat : MonoBehaviour
{
    public int damage = 1;
    public Transform attack_point;
    public void attack()
    {
        //≤È’“µ–»À
        Collider2D[] hit_player = Physics2D.OverlapCircleAll(attack_point.position, 0.5f);
        foreach (Collider2D col in hit_player)
        {
            if (col.CompareTag("Player"))
            {
                player playerScript = col.GetComponent<player>();
                if (playerScript != null)
                {
                    playerScript.changeHeath(-damage);
                    playerScript.GetComponent<playerMove>().Knockback(transform, 5f);
                }
            }
        }
    }
}