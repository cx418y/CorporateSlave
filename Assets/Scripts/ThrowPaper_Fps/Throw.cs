using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour
{
    public GameObject Gun; // 物体A
    public GameObject Enemy; // 物体B
    public GameObject BulletPrefab; // 物体a的预制体
    public float minDamage = 20f; // 最小伤害
    public float maxDamage = 50f; // 最大伤害

    private Vector3 initialPosition; // 物体A的初始位置
    private Rigidbody rbA; // 物体A的刚体
    private float startTime; // 鼠标点击的开始时间
    private float throwForce = 100f; // 投掷力度

    void Start()
    {
        rbA = BulletPrefab.GetComponent<Rigidbody>();
        initialPosition = Gun.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ThrowObjectA();
        }
    }

    void ThrowObjectA()
    {
        float holdTime = Time.time - startTime;
        float Damage = CalculateDamage(holdTime);

        // 给物体A一个向前的速度
        // rbA.velocity = transform.forward * throwForce * holdTime;

        // 生成物体a在初始位置
        GameObject NewObject = Instantiate(BulletPrefab, initialPosition, Quaternion.identity);
        Bullet BulletObj = NewObject.GetComponent
                            <Bullet>();
        if(BulletObj != null)
        {
            BulletObj.SetDamage(Damage);
        }
        // 计算投掷方向
        Vector3 throwDirection = ( Enemy.transform.position - transform.position).normalized;
        // 投掷物体A
        NewObject.GetComponent<Rigidbody>().AddForce(throwDirection * throwForce * holdTime, ForceMode.Impulse);
        Debug.Log("Enemy.transform.position: " + Enemy.transform.position);
        Debug.Log("transform.position: " + transform.position);

        Destroy(NewObject, 2);

        // StartCoroutine(GenerateNewBullet());
    }

    IEnumerator GenerateNewBullet()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(BulletPrefab, initialPosition, Quaternion.identity);
    }

    float CalculateDamage(float HoldTime)
    {
        // 根据点击时间来计算造成的伤害
        float Damage = Mathf.Lerp(minDamage, maxDamage, Mathf.Clamp01(HoldTime / 1f));
        return Damage;
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Enemy)
        {
            float damage = CalculateDamage(Time.time - startTime);
            Health health = collision.gameObject.GetComponent
                            <Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
                if (health.currentHealth <= 0)
                {
                    // 摧毁物体B
                    Destroy(collision.gameObject);
                    // 加载场景sceneC
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }*/
}
