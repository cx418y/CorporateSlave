using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �ƶ��ٶ�
    public float distanceToLookDown = 3f; // ÿ�߶��پ����ʼ���¿�
    public float lookDownAngle = 10f; // ���¿��ĽǶ�
    public float lookDownSpeed = 5f; // ���¿����ٶ�
    public Light worldLight; // ����ƹ�
    public float lightlightIntensity = 10f;

    private Transform playerCamera; // ��������Transform���
    private float distanceMovedSinceLastLookDown = 0f; // ���ϴ����¿��������ƶ��ľ���

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

            // �����ƶ����벢����Ƿ���Ҫ���¿�
            distanceMovedSinceLastLookDown += distance;
            if (distanceMovedSinceLastLookDown >= distanceToLookDown)
            {
                LookDown();
                distanceMovedSinceLastLookDown = 0f; // �������ƶ�����
                // ���µƹ�ǿ��
                UpdateLightIntensity();
            }

            
        }
    }

    void LookDown()
    {
        Debug.Log("LookDown");  
        // ����Ŀ��Ƕ�
        Quaternion targetRotation = Quaternion.Euler(lookDownAngle, playerCamera.eulerAngles.y, playerCamera.eulerAngles.z);

        // ʹ�ò�ֵƽ���ظı�����Ƕ�
        playerCamera.rotation = Quaternion.Lerp(playerCamera.rotation, targetRotation, lookDownSpeed * Time.deltaTime);
    }

    void UpdateLightIntensity()
    {
        Debug.Log(worldLight.intensity);
        // �����ƶ������𽥽��͵ƹ�ǿ��
        // float lightIntensity = 1f - (distanceMovedSinceLastLookDown / distanceToLookDown);
        // float lightIntensity = 100f ;
        worldLight.intensity = Mathf.Clamp(worldLight.intensity-lightlightIntensity, 0f, 1f);
    }
}
