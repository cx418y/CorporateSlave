using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度
    public float distanceToLookDown = 3f; // 每走多少距离后开始向下看
    public float lookDownAngle = 10f; // 向下看的角度
    public float lookDownSpeed = 5f; // 向下看的速度
    public Light[] worldLights; // 世界灯光
    public float lightDownSpeed = 0.1f;

    private Transform playerCamera; // 玩家相机的Transform组件
    private float distanceMovedSinceLastLookDown = 0f; // 自上次向下看以来已移动的距离

    void Start()
    {
        // 获取玩家相机的Transform组件
        playerCamera = Camera.main.transform;
    }

    void Update()
    {
        // 按住W键往前走
        if (Input.GetKey(KeyCode.W))
        {
            // 移动玩家
            float distance = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * distance);

            // 更新移动距离并检查是否需要向下看
            // distanceMovedSinceLastLookDown += distance;
            // if (distanceMovedSinceLastLookDown >= distanceToLookDown)
            // {
                LookDown();
                // distanceMovedSinceLastLookDown = 0f; // 重置已移动距离
                // 更新灯光强度
                UpdateLightIntensity();
            // }

            
        }
    }

    void LookDown()
    {
        // Debug.Log("LookDown");  
        // 计算目标角度
        // Quaternion targetRotation = Quaternion.Euler(lookDownAngle, playerCamera.eulerAngles.y, playerCamera.eulerAngles.z);

        // 使用插值平滑地改变相机角度
        // playerCamera.rotation = Quaternion.Lerp(playerCamera.rotation, targetRotation, lookDownSpeed * Time.deltaTime);
        playerCamera.transform.Rotate(lookDownSpeed * Time.deltaTime, 0, 0);

    }

    void UpdateLightIntensity()
    {
        // Debug.Log(worldLight.intensity);
        // 根据移动距离逐渐降低灯光强度
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
