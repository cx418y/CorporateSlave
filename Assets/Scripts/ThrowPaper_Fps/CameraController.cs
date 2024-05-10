using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5f; // �����ת�ٶ�
    public float rotationLimit = 20f; // �����ֱ��ת�Ƕ�����
    public float sensitivity = 2f; // ���������
    public float maxHorizontalRotation = 30f; // ���ˮƽ��ת�Ƕ�����
    public float minHorizontalRotation = -30f; // ���ˮƽ��ת�Ƕ�����

    private float verticalRotation = 0f; // ��ֱ��ת�Ƕ�

    void Update()
    {
        // ��ȡ����ƶ�����
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // ����ˮƽ��ת
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // ���㴹ֱ��ת
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -rotationLimit, rotationLimit);

        // ����ˮƽ��ת�Ƕ�
        transform.localEulerAngles = new Vector3(ClampAngle(transform.localEulerAngles.x, minHorizontalRotation, maxHorizontalRotation), transform.localEulerAngles.y, 0);
        // Ӧ����ת
        transform.localRotation = Quaternion.Euler(verticalRotation, transform.localEulerAngles.y, 0);

        
        
    }

    float ClampAngle(float angle, float min, float max)
    {
        // ���ƽǶ��� min �� max ֮��
        if (angle < -360f)
        {
            angle += 360f;
        }
        if (angle > 360f)
        {
            angle -= 360f;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
