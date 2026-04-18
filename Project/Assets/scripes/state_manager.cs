using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_manager : MonoBehaviour
{
    //这是确保不冲突
    public static state_manager instanc;//单例模式

    [Header("combat state")]
    public int damage;//伤害值
    public float weapon;//武器攻击力
    public float back;//后退力
    public float back_time;
    public float sun_time;

    [Header("Movement States")]
    public int speed;

    [Header("Health State")]
    public int health;
    public int max_health;

    private void Awake()
    {
        if(instanc == null)
        {
            instanc = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
