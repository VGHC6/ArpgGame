using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class player : MonoBehaviour
{
    public int currentHealth = 2;
    public int maxHealth = 3;
    public TMP_Text healthText;//生命值显示
    public Animator animator_health;//动画控制器   

    public void Start()
    {
        healthText.text = "Health: " + currentHealth.ToString() + "/" + maxHealth.ToString();//初始化显示生命值
    }
    public void changeHeath(int amount)
    {
        currentHealth += amount;
        animator_health.Play("Heath");//播放动画
        healthText.text = "Health: " + currentHealth.ToString() + "/" + maxHealth.ToString();//更新显示生命值
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }
    }
}
