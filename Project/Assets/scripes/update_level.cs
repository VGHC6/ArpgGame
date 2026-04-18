using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class update_level : MonoBehaviour
{
    public int level;
    public int current_level;
    public int level_count=10;
    public float update_exp = 1.2f;
    public TMP_Text level_text;
    public Slider exp_slider;
    //start
    void Start()
    {
        Update_Ui();
    }

    public void GainExp(int exp)
    {
        current_level += exp;
        if (current_level > level_count) { 
            Level_Up();
        }
        Update_Ui();
    }

    //监听事件
    public void OnEnable()
    {
        enemy_heath.OnExpReward += GainExp;
    }

    public void OnDisable()
    {
        enemy_heath.OnExpReward -= GainExp;
    }


    public void Level_Up()
    {
        level += 1;
        current_level = 0;
        //升级所需经验增加
        level_count=(int)(level*update_exp);
    }

    public void Update_Ui()
    {
        exp_slider.maxValue = level_count;
        exp_slider.value = current_level;
        //文本
        level_text.text = "Level: " + level;
    }
}
