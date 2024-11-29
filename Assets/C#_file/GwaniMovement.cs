using UnityEngine;

public class JungjoonMovement : MonoBehaviour
{
    public float speed = 5f; // 이동 속도

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // WASD 키 입력 처리
        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.down;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;

        // 이동 처리
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
