using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public int facingDirection = 1;//1表示向右，-1表示向左
    public Rigidbody2D rb;
    public Animator animator;//动画控制器

    private bool isback;//是否被击退

    //与战斗脚本通信
    public player_combat combat;

    private void Update()
    {
        //是否按下攻击键
        if (Input.GetButtonDown("Slash"))
        {
            combat.Attack();
        }
    }

    // Update is called once per frame
    void FixedUpdate()//以固定的帧率运行，适合物理相关的更新
    {
        if (isback == false)//如果正在被击退
        {
            float horizontal = Input.GetAxis("Horizontal");//监听左右方向
            float vertical = Input.GetAxis("Vertical");//监听上下方向

            //根据输入设置动画参数，Mathf.Abs()函数返回绝对值，确保动画参数为正数
            animator.SetFloat("horizontal", Mathf.Abs(horizontal));//设置动画参数
            animator.SetFloat("vertical", Mathf.Abs(vertical));

            if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
            {
                //如果向右移动且当前朝向为左
                Flip();//反转角色
            }
            rb.velocity = new Vector2(horizontal, vertical) * speed;//设置速度
        }
    }

    void Flip()
    {
        facingDirection *= -1;//改变朝向
        transform.localScale = new Vector3(facingDirection * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);//反转角色的x轴缩放
    }

    public void Knockback(Transform position, float knockbackForce)
    {
        isback = true;//设置被击退状态
        Vector2 knockbackDirection = (transform.position - position.position).normalized;
        rb.velocity = knockbackDirection * knockbackForce;//设置击退速度
        StartCoroutine(back_counter());
    }

    IEnumerator back_counter()
    {
        yield return new WaitForSeconds(1);//等待1秒
        rb.velocity = Vector2.zero;//停止移动
        isback = false;//取消被击退状态
    }
}
