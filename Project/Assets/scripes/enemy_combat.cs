using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_combat : MonoBehaviour
{
    public int damage = 1;
    public Transform attack_point;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().changeHeath(-damage);

            Debug.Log("enemy hit player");
        }
    }

    public void attack()
    {
        //查找敌人
        Collider2D[] hit_player = Physics2D.OverlapCircleAll(attack_point.position, 0.5f);
        foreach (Collider2D col in hit_player)
        {
            if (col.CompareTag("Player"))
            {
                player playerScript = col.GetComponent<player>();
                if (playerScript != null)
                {
                    playerScript.changeHeath(-damage);
                    Debug.Log("敌人技能攻击到玩家");
                }
            }
        }
    }
}