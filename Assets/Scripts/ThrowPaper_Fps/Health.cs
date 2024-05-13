using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // �������ֵ
    public float currentHealth; // ��ǰ����ֵ

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
