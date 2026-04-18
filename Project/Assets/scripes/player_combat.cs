using UnityEngine;

public class player_combat : MonoBehaviour
{
    public Animator animatior;
    public float timer = 0.5f;
    public float counter = 0;
    public LayerMask enemyLayer;
    public Transform attackPoint; // 需在Inspector中赋值
    public float back = 50;

    private void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (counter <= 0 && animatior != null)
        {
            animatior.SetBool("attack", true);
            counter = timer; // 修复：应重置为timer而非0
        }
    }

    public void deal_damage()
    {
        // 1. 检查attackPoint是否赋值
        if (attackPoint == null)
        {
            Debug.LogError("攻击点未设置！请检查Inspector");
            return;
        }

        // 2. 检测范围内的敌人
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, 1f, enemyLayer);

        foreach (Collider2D hit in hits)
        {
            if (hit == null) continue;

            // 3. 处理敌人血量
            enemy_heath health = hit.GetComponent<enemy_heath>();
            if (health != null)
            {
                health.change_health(-1);
                Debug.Log($"对敌人 {hit.name} 造成伤害");
            }
            else
            {
                Debug.LogWarning($"敌人 {hit.name} 缺少enemy_heath组件");
            }

            // 4. 处理击退效果
            enemt_back knockback = hit.GetComponent<enemt_back>();
            if (knockback != null)
            {
                knockback.back(transform, back, 0.2f);
            }
            else
            {
                Debug.LogWarning($"敌人 {hit.name} 缺少enemt_back组件");
            }
        }
    }

    public void EndAttack()
    {
        if (animatior != null)
        {
            animatior.SetBool("attack", false);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, 1f);
        }
    }
}
