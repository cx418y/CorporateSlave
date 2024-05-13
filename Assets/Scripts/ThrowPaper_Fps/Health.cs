using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // 最大生命值
    public float currentHealth; // 当前生命值

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        Debug.Log("damaged, currentHealth is: " + currentHealth);
    }
}
