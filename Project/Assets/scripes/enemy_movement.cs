using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform player_transform;
    public float speed = 5f;//敌人移动速度

    public float attack_timer = 2;//攻击计时器
    public float attack_timering = 0f;
    private int move_forword = 1;

    public LayerMask player_mask;
    private Animator animatior;//动画控制器
    private enemy_state state;//敌人状态
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;

        animatior = GetComponent<Animator>();
        change_state(enemy_state.is_stand);
    }

    void Flip()
    {//反转敌人朝向
        move_forword *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
        //计时器增加
        if (attack_timering > 0)
        {
            attack_timering -= Time.deltaTime;
        }
        if (state == enemy_state.is_move)
        {
            chansing();
        }
        else if (state == enemy_state.is_attack)
        {
            //速度为0，停止移动
            rb.velocity = Vector2.zero;
        }
    }
    void chansing()
    {
        //敌人追逐玩家
        Vector2 direction = (player_transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
        if (player_transform.position.x > transform.position.x && move_forword == -1
           || player_transform.position.x < transform.position.x && move_forword == 1)
        {
            Flip();//反转敌人朝向
        }
    }


    private void CheckForPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f, player_mask);
        if (colliders.Length > 0)
        {
            player = colliders[0].transform;
            if (Vector2.Distance(transform.position, player_transform.position) < 1 && attack_timering <= 0)
            {
                attack_timering = attack_timer;
                change_state(enemy_state.is_attack);
            }
            else if (Vector2.Distance(transform.position, player_transform.position) > 1)
            {
                change_state(enemy_state.is_move);
            }
            else
            {
                change_state(enemy_state.is_stand);
            }
        }
    }

    private void change_state(enemy_state newState)
    {
        //改变敌人状态
        if (state == enemy_state.is_stand)
        {
            animatior.SetBool("is_stand", false);
        }
        else if (state == enemy_state.is_move)
        {
            animatior.SetBool("is_move", false);
        }
        else if (state == enemy_state.is_attack)
        {
            animatior.SetBool("is_attack", false);
        }

        state = newState;
        //重新设置动画参数
        if (state == enemy_state.is_stand)
        {
            animatior.SetBool("is_stand", true);
        }
        else if (state == enemy_state.is_move)
        {
            animatior.SetBool("is_move", true);
        }
        else if (state == enemy_state.is_attack)
        {
            animatior.SetBool("is_attack", true);
        }
    }




    public enum enemy_state
    {
        is_move,
        is_stand,
        is_attack
    }
}