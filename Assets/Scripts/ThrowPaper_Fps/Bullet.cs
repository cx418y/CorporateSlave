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
        if (collision.gameObject.CompareTag("Enemy")) // 假设物体 B 的 tag 为 "B"
        {
            
            Health health = collision.gameObject.GetComponent
                            <Health>();
            if (health != null)
            {
                health.TakeDamage(Damage);
                if (health.currentHealth <= 0)
                {
                    // 摧毁物体B
                    Destroy(collision.gameObject);
                    // 加载场景sceneC
                    SceneManager.LoadScene("SampleScene");
                }
            }

            Destroy(gameObject); // 碰撞到物体 B 后销毁自身
        }
    }

    public void SetDamage(float InitDamage)
    {
        Damage = InitDamage;
    }
}
