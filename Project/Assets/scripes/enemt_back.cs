using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static enemy_movement;

public class enemt_back : MonoBehaviour
{
    private Rigidbody2D rb;
    private enemy_movement enemy_movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void back(Transform player, float back, float stun)
    {
        GetComponent<enemy_movement>().change_state(enemy_state.is_back);
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * back;
        stun_time(stun);
    }

    IEnumerator stun_time(float stun)
    {
        yield return new WaitForSeconds(stun);
        GetComponent<enemy_movement>().change_state(enemy_state.is_stand);
    }
}
