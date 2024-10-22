using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;

    // Thêm biến tham chiếu tới Animator
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lấy component Animator từ nhân vật
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float yStore = moveDirection.y;

        // Tính toán hướng di chuyển dựa trên input
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        // Kiểm tra xem nhân vật có đang ở trên mặt đất không
        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        // Áp dụng trọng lực
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

        // Di chuyển nhân vật
        controller.Move(moveDirection * Time.deltaTime);

        // Tính toán tốc độ hiện tại (bỏ qua trục Y)
        Vector3 moveDirectionNoY = new Vector3(moveDirection.x, 0, moveDirection.z);
        float speed = moveDirectionNoY.magnitude;

        // Cập nhật giá trị "Speed" trong Animator (để điều khiển animation)
        animator.SetFloat("speed", speed);
    }
}
