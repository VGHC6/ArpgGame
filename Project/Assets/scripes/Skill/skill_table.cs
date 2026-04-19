using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class skill_table : MonoBehaviour
{
    //设置技能
    public skill_table[] skill_list;
    public sill_list sill_List;
    public int current_level = 0;//当前等级
    public int max_level = 0;//最大等级
    public TMP_Text level_text;//等级文本
    //按钮脚本
    public Button skill_button;
    public bool is_open = false;//替换

 
    //事件
    public static event Action<skill_table> OnSkillLevelUp;//升级事件
    public static event Action<skill_table> OnMaxLevel;//满级事件;
    public void OnValidate()
    {
        if (sill_List != null && level_text != null)
        {
            update_level();
        }
    }

    void Start()
    {
        if (sill_List != null)
        {
            max_level = sill_List.max_level;
        }
    }


    public void try_update()
    {
        //更新等级
        if (is_open && current_level <= max_level) {
            current_level += 1;
            OnSkillLevelUp?.Invoke(this);
            if (current_level >= max_level)
            {
                OnMaxLevel?.Invoke(this);//满级事件
            }
            update_level();
        }
    } 

    public bool current_lock()
    {
        foreach (var item in skill_list)
        {
            if(!item.is_open&& item.current_level < max_level)
            {
                return false;
            }
        }
        return true;
    }


    public void unlock()
    {
        is_open = true;
        update_level();
    }

    public void update_level()
    {
        //更新等级
        if (is_open)
        {
            skill_button.interactable = true;
            level_text.text = current_level.ToString() + "/" + sill_List.max_level.ToString();
        }
        else {
            //技能还未解锁
            skill_button.interactable = false;
            level_text.text = "???";
        }
    }
}
