using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class state_ui : MonoBehaviour
{
    public GameObject[] state_ui_obj;
    public CanvasGroup canvas_group;
    private bool state_open = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(state_manager.instanc.damage);
        update_state_ui();//初始化UI
    }

    private void Update()
    {
        //按下按钮修改canvas_group
        if (Input.GetButtonDown("toggleState"))
        {
            if (state_open)
            {
                Time.timeScale = 1;//恢复游戏
                canvas_group.alpha = 0;
                state_open = false;
            }
            else
            {
                Time.timeScale = 0;//暂停游戏
                canvas_group.alpha = 1;//显示UI
                state_open = true;//打开状态
            }
        }
    }
    void update_state_ui()
    {
        Debug.Log(state_manager.instanc.damage);
        state_ui_obj[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + state_manager.instanc.damage;//显示伤害值
    }
}
