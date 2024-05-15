using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour
{
    public GameObject Gun; // 物体A
    public GameObject[] Enemies; // 物体B
    public GameObject BulletPrefab; // 物体a的预制体
    public float minDamage = 20f; // 最小伤害
    public float maxDamage = 50f; // 最大伤害
    public float throwForce = 3f; // 投掷力度
    private Vector3 initialPosition; // 物体A的初始位置
    private Rigidbody rbA; // 物体A的刚体
    private float startTime; // 鼠标点击的开始时间
    
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

        // 给物体A一个向前的速度
        // rbA.velocity = transform.forward * throwForce * holdTime;

        // 生成物体a在初始位置
        GameObject NewObject = Instantiate(BulletPrefab, initialPosition, BulletPrefab.transform.rotation);
        Bullet BulletObj = NewObject.GetComponent
                            <Bullet>();
        if(BulletObj != null)
        {
            BulletObj.SetDamage(Damage);
        }
        // 计算投掷方向
        Vector3 targetPosition = GetMouseClickPosition();
        Vector3 throwDirection = (targetPosition - initialPosition).normalized;
        // 投掷物体A
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
        // 根据点击时间来计算造成的伤害
        float Damage = Mathf.Lerp(minDamage, maxDamage, Mathf.Clamp01(HoldTime / 1f));
        return Damage;
    }


    Vector3 GetMouseClickPosition()
    {
        // 获取鼠标点击位置
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
            // 检测敌人是否被全部击倒
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

            // 等待一秒
            yield return new WaitForSeconds(1f);
        }
    }

}
