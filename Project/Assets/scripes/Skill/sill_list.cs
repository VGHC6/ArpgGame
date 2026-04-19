using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill List", menuName = "Skill/Skill List")]//于在 Unity 编辑器中自定义创建 ScriptableObject 的菜单项和默认文件名
public class sill_list : ScriptableObject//允许你创建可以在多个场景之间共享的数据对象，而不需要将这些对象附加到游戏对象上
{
    public string sill_name;//技能名称
    public int max_level;
    public Sprite skill_icon;
}
