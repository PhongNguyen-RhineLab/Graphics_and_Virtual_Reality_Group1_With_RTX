using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLight : MonoBehaviour
{
    // Khai báo biến tham chiếu tới component Light
    private Light sceneLight;

    // Mảng màu có sẵn để thay đổi
    private Color[] colors = { Color.yellow, Color.white, Color.cyan};
    private int currentColorIndex = 0;


    // Biến điều khiển cường độ sáng
    private float intensityChangeStep = 0.5f; // Mỗi lần nhấn sẽ tăng/giảm cường độ sáng
    private float minIntensity = 0f;
    private float maxIntensity = 5f;

    void Start()
    {
        // Lấy component Light từ GameObject
        sceneLight = GetComponent<Light>();

        // Thiết lập màu ban đầu
        sceneLight.color = colors[currentColorIndex];
    }

    void Update()
    {
        // Tăng dần thời gian kể từ lần thay đổi màu cuối (cho thay đổi màu tự động)


        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0) // Nếu có lăn chuột
        {
            sceneLight.intensity = Mathf.Clamp(sceneLight.intensity + scroll * intensityChangeStep, minIntensity, maxIntensity);
        }
        // Thay đổi màu khi nhấn phím mũi tên trái/phải
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Đổi sang màu trước đó trong mảng khi nhấn mũi tên trái
            currentColorIndex = (currentColorIndex - 1 + colors.Length) % colors.Length;
            sceneLight.color = colors[currentColorIndex];
       
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Đổi sang màu tiếp theo trong mảng khi nhấn mũi tên phải
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            sceneLight.color = colors[currentColorIndex];
         
        }

        // Bật/Tắt nguồn sáng khi nhấn phím "B"
        if (Input.GetKeyDown(KeyCode.B))
        {
            sceneLight.enabled = !sceneLight.enabled;
        }

      

        // Giảm cường độ sáng khi nhấn phím "G"
        if (Input.GetKey(KeyCode.G))
        {
            sceneLight.intensity = Mathf.Clamp(sceneLight.intensity - intensityChangeStep * Time.deltaTime, minIntensity, maxIntensity);
        }
    }

    
}
