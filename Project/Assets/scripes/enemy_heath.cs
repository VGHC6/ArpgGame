using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_heath : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 3;
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
            Destroy(gameObject);
        }
    }
}

