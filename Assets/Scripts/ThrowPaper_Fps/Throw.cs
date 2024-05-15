using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour
{
    public GameObject Gun; // ����A
    public GameObject[] Enemies; // ����B
    public GameObject BulletPrefab; // ����a��Ԥ����
    public float minDamage = 20f; // ��С�˺�
    public float maxDamage = 50f; // ����˺�
    public float throwForce = 3f; // Ͷ������
    private Vector3 initialPosition; // ����A�ĳ�ʼλ��
    private Rigidbody rbA; // ����A�ĸ���
    private float startTime; // ������Ŀ�ʼʱ��
    
    private int curThrowIndex = 0;

    void Start()
    {
        rbA = BulletPrefab.GetComponent<Rigidbody>();
        initialPosition = Gun.transform.position;
        StartCoroutine(CheckMouseClick());
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
        GameObject NewObject = Instantiate(BulletPrefab, initialPosition, BulletPrefab.transform.rotation);
        Bullet BulletObj = NewObject.GetComponent
                            <Bullet>();
        if(BulletObj != null)
        {
            BulletObj.SetDamage(Damage);
        }
        // ����Ͷ������
        Vector3 targetPosition = GetMouseClickPosition();
        Vector3 throwDirection = (targetPosition - initialPosition).normalized;
        // Ͷ������A
        NewObject.GetComponent<Rigidbody>().AddForce(throwDirection * throwForce * holdTime, ForceMode.Impulse);

        Destroy(NewObject, 2);
       /* curThrowIndex++;
        if(curThrowIndex >= Enemys.Length)
        {
            SceneManager.LoadScene("SampleScene");
        }*/
        // Debug.Log("throwDirection: " + throwDirection);

        // StartCoroutine(GenerateNewBullet());
    }

/*    IEnumerator GenerateNewBullet()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(BulletPrefab, initialPosition, Quaternion.identity);
    }*/

    float CalculateDamage(float HoldTime)
    {
        // ���ݵ��ʱ����������ɵ��˺�
        float Damage = Mathf.Lerp(minDamage, maxDamage, Mathf.Clamp01(HoldTime / 1f));
        return Damage;
    }


    Vector3 GetMouseClickPosition()
    {
        // ��ȡ�����λ��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    IEnumerator CheckMouseClick()
    {
        while (true)
        {
            bool AllDestroyed = true;
            // �������Ƿ�ȫ������
            foreach (GameObject enemy in Enemies)
            {
                if (enemy != null)
                {
                    AllDestroyed = false;
                    break;
                }
            }
            if(AllDestroyed)
            {
                SceneManager.LoadScene("Windows");
            }

            // �ȴ�һ��
            yield return new WaitForSeconds(1f);
        }
    }

}
