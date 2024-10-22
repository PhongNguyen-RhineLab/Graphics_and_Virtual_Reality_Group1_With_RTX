using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnNutQuayQuat3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject quat1;

    public Vector3 moveDirection;
    private bool isRotating = false;
    private float rorateSpeed = 500f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Gọi hàm kiểm tra nhấn chuột
        CheckMouseClick();

        // Logic quay quạt
        if (isRotating)
        {
            quat1.transform.Rotate(Vector3.up * rorateSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            rorateSpeed +=150f;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            rorateSpeed -=150f;
        }
    }

    // Hàm kiểm tra nhấn chuột
    void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // Kiểm tra khi nhấn chuột trái
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // Kiểm tra xem có nhấn vào bất kỳ đối tượng nào trong cảnh hay không
            if (Physics.Raycast(ray, out hitInfo))
            {
                // Lấy đối tượng đã click vào
                GameObject clickedObject = hitInfo.collider.gameObject;

                if (clickedObject.name == "fanswitch3")
                {
                    Debug.Log("Clicked on object: " + clickedObject.name);

                    // Đổi trạng thái quay quạt
                    isRotating = !isRotating;

                }


            }
        }
    }
}
