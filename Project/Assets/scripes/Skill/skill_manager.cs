using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class skill_manager : MonoBehaviour
{
    public skill_table[] skill_tables;//点数技能表
    public TMP_Text skill_text;//技能文本
    public int available_skill_point = 0;//可用的技能点数

    private void Start()
    {
        //初始化技能表
        foreach (skill_table skill_table in skill_tables)
        {
            skill_table.skill_button.onClick.AddListener(() => check_up(skill_table));//给按钮添加点击事件
            update_point(0);
        }
    }

    public void check_up(skill_table skill_table)
    {
        if (available_skill_point > 0)
        {
            skill_table.update_level();
        }
    }

    public void OnEnable()
    {
        skill_table.OnSkillLevelUp += point_spend;
        skill_table.OnMaxLevel += disable_skill;
    }
    
      public void OnDisEnable()
    {
        skill_table.OnSkillLevelUp -= point_spend;
        skill_table.OnMaxLevel += disable_skill;
    }

    void update_point(int point)
    {
        available_skill_point += point;
        skill_text.text = "Point:"+ available_skill_point;
    }

    private void point_spend(skill_table skill_table)
    {
        if (available_skill_point > 0)
        {
            update_point(-1);
        }
    }

    private void disable_skill(skill_table skill_table)
    {
        foreach (var item in skill_tables)
        {
            if(!item.is_open&& item.current_lock())
            item.unlock();
        }
    }

}
