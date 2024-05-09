using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5f; // 相机旋转速度
    public float rotationLimit = 20f; // 相机垂直旋转角度限制
    public float sensitivity = 2f; // 鼠标灵敏度
    public float maxHorizontalRotation = 30f; // 相机水平旋转角度限制
    public float minHorizontalRotation = -30f; // 相机水平旋转角度限制

    private float verticalRotation = 0f; // 垂直旋转角度

    void Update()
    {
        // 获取鼠标移动距离
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // 计算水平旋转
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // 计算垂直旋转
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -rotationLimit, rotationLimit);

        // 限制水平旋转角度
        transform.localEulerAngles = new Vector3(ClampAngle(transform.localEulerAngles.x, minHorizontalRotation, maxHorizontalRotation), transform.localEulerAngles.y, 0);
        // 应用旋转
        transform.localRotation = Quaternion.Euler(verticalRotation, transform.localEulerAngles.y, 0);

        
        
    }

    float ClampAngle(float angle, float min, float max)
    {
        // 限制角度在 min 和 max 之间
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
