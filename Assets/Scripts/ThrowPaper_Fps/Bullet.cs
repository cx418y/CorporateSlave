using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    public float Damage = 20f;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Trigger");
        if (collision.gameObject.CompareTag("Enemy")) // �������� B �� tag Ϊ "B"
        {
            
            Health health = collision.gameObject.GetComponent
                            <Health>();
            if (health != null)
            {
                health.TakeDamage(Damage);
                if (health.currentHealth <= 0)
                {
                    // �ݻ�����B
                    Destroy(collision.gameObject);
                    // ���س���sceneC
                    SceneManager.LoadScene("SampleScene");
                }
            }

            Destroy(gameObject); // ��ײ������ B ����������
        }
    }

    public void SetDamage(float InitDamage)
    {
        Damage = InitDamage;
    }
}
