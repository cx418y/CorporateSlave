using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement1 : MonoBehaviour
{
    public float moveSpeed = 5f; // �ƶ��ٶ�
    public float distanceToLookDown = 3f; // ÿ�߶��پ����ʼ���¿�
    public float lookDownAngle = 10f; // ���¿��ĽǶ�
    public float lookDownSpeed = 5f; // ���¿����ٶ�
    public Light[] worldLights; // ����ƹ�
    public float lightDownSpeed = 0.1f;
    public float distanceToLoadScene = 10f; // �ƶ����پ������س���
    public string nextSceneName = "ClassScence";

    private Transform playerCamera; // ��������Transform���
    private float distanceMovedSinceLastLookDown = 0f; // ���ϴ����¿��������ƶ��ľ���
    private float totalDistanceMoved = 0f; // �ܹ��ƶ��ľ���

    void Start()
    {
        // ��ȡ��������Transform���
        playerCamera = Camera.main.transform;
    }

    void Update()
    {
        // ��סW����ǰ��
        if (Input.GetKey(KeyCode.W))
        {
            // �ƶ����
            float distance = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * distance);
            totalDistanceMoved += distance;

            // �����ƶ����벢����Ƿ���Ҫ���¿�
            // distanceMovedSinceLastLookDown += distance;
            // if (distanceMovedSinceLastLookDown >= distanceToLookDown)
            // {
            LookDown();
                // distanceMovedSinceLastLookDown = 0f; // �������ƶ�����
                // ���µƹ�ǿ��
                UpdateLightIntensity();
            // }

            if (totalDistanceMoved >= distanceToLoadScene)
            {
                SceneManager.LoadScene(nextSceneName);
            }



        }
    }

    void LookDown()
    {
        // Debug.Log("LookDown");  
        // ����Ŀ��Ƕ�
        // Quaternion targetRotation = Quaternion.Euler(lookDownAngle, playerCamera.eulerAngles.y, playerCamera.eulerAngles.z);

        // ʹ�ò�ֵƽ���ظı�����Ƕ�
        // playerCamera.rotation = Quaternion.Lerp(playerCamera.rotation, targetRotation, lookDownSpeed * Time.deltaTime);
        playerCamera.transform.Rotate(lookDownSpeed * Time.deltaTime, 0, 0);

    }

    void UpdateLightIntensity()
    {
        // Debug.Log(worldLight.intensity);
        // �����ƶ������𽥽��͵ƹ�ǿ��
        // float lightIntensity = 1f - (distanceMovedSinceLastLookDown / distanceToLookDown);
        // float lightIntensity = 100f ;
        // worldLight.intensity = Mathf.Clamp(worldLight.intensity-lightlightIntensity, 0f, 1f);
        Debug.Log(worldLights[0].intensity);
        foreach(Light light in worldLights)
        {
            if (light.intensity > 0)
            {
                light.intensity -= Time.deltaTime * lightDownSpeed;
            }
        }
        
    }
}
