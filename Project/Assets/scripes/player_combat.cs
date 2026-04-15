using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_combat : MonoBehaviour
{
    public Animator animatior;
    public float timer = 0.5f;
    public float counter = 0;
    public LayerMask enemyLayer;
    public Transform attackPoint;

    public float back=50;
    private void Update()
    {
        //µ¹¼ÆÊ±
        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if (counter <= 0)
        {
            animatior.SetBool("attack", true);
           
            counter = 0;
        }
    }

    public void deal_damage()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, 1f, enemyLayer);
        if (hit.Length > 0)
        {
            if (hit[0] != null) { 
            hit[0].GetComponent<enemy_heath>().change_health(-1);
                print(transform);
            hit[0].GetComponent<enemt_back>().back(transform, back,0.2f);
            }
        }
    }

    //½áÊø¹¥»÷
    public void EndAttack()
    {
        animatior.SetBool("attack", false);
    }


    //»æÖÆ¹¥»÷·¶Î§
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, 1f);
    }
}
