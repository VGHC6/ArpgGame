using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_heath : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 3;
    //事件脚本
    public int exp_reward = 3;//经验奖励
    public delegate void EXP_REWARD_DELEGATE(int amount);//定义一个委托类型
    public static event EXP_REWARD_DELEGATE OnExpReward;//定义一个事件类型，并声明一个事件委托
    // Start is called before the first frame update

    private void Start()
    {
        health = maxHealth;
    }

    public void change_health(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            //触发事件
            OnExpReward(exp_reward);
            Destroy(gameObject);
        }
    }
}

