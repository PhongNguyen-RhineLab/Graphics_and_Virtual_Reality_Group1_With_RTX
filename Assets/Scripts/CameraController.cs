using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public bool useOffSetValue;

    public float rorateSpeed;
    public GameObject pivot;

    // Start is called before the first frame update
    void Start()
    {

        if (!useOffSetValue)
        {
            offset = target.transform.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        // Kiểm tra nếu không nhấn giữ Shift thì cho phép xoay camera
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            // Lấy vị trí x, y của chuột và xoay mục tiêu
            float horizontal = Input.GetAxis("Mouse X") * rorateSpeed;
            target.transform.Rotate(0, horizontal, 0);

            float vertical = Input.GetAxis("Mouse Y") * rorateSpeed;
            pivot.transform.Rotate(vertical, 0, 0);

            // Giới hạn góc xoay theo trục X của pivot
            if (pivot.transform.rotation.eulerAngles.x > 45f && pivot.transform.rotation.eulerAngles.x < 180f)
            {
                pivot.transform.rotation = Quaternion.Euler(45f, 0, 0);
            }
            if (pivot.transform.rotation.eulerAngles.x > 180f && pivot.transform.rotation.eulerAngles.x < 315f)
            {
                pivot.transform.rotation = Quaternion.Euler(315f, 0, 0);
            }
        }

        // Di chuyển máy ảnh dựa trên góc quay hiện tại
        float Yangle = target.transform.eulerAngles.y;
        float Xangle = pivot.transform.eulerAngles.x;
        Quaternion roration = Quaternion.Euler(Xangle, Yangle, 0);
        transform.position = target.transform.position - (roration * offset);

        // Đảm bảo camera không nằm dưới đối tượng
        if (transform.position.y < target.transform.position.y-10)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y - 0.5f, transform.position.z);
        }

        // Camera luôn nhìn về phía target
        transform.LookAt(target.transform);
    }

    private void FixedUpdate()
    {
        // Tùy chọn: giữ nguyên transform.position
    }
}
