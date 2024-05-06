using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour
{
    public GameObject Gun; // ����A
    public GameObject Enemy; // ����B
    public GameObject BulletPrefab; // ����a��Ԥ����
    public float minDamage = 20f; // ��С�˺�
    public float maxDamage = 50f; // ����˺�

    private Vector3 initialPosition; // ����A�ĳ�ʼλ��
    private Rigidbody rbA; // ����A�ĸ���
    private float startTime; // ������Ŀ�ʼʱ��
    private float throwForce = 100f; // Ͷ������

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

        // ������Aһ����ǰ���ٶ�
        // rbA.velocity = transform.forward * throwForce * holdTime;

        // ��������a�ڳ�ʼλ��
        GameObject NewObject = Instantiate(BulletPrefab, initialPosition, Quaternion.identity);
        Bullet BulletObj = NewObject.GetComponent
                            <Bullet>();
        if(BulletObj != null)
        {
            BulletObj.SetDamage(Damage);
        }
        // ����Ͷ������
        Vector3 throwDirection = ( Enemy.transform.position - transform.position).normalized;
        // Ͷ������A
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
        // ���ݵ��ʱ����������ɵ��˺�
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
                    // �ݻ�����B
                    Destroy(collision.gameObject);
                    // ���س���sceneC
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }*/
}
