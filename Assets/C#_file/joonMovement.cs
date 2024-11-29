using UnityEngine;

public class GwaniMovement : MonoBehaviour
{
    public float speed = 5f; // 이동 속도

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // 화살표 키 입력 처리
        if (Input.GetKey(KeyCode.UpArrow))
            moveDirection += Vector3.up;
        if (Input.GetKey(KeyCode.DownArrow))
            moveDirection += Vector3.down;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow))
            moveDirection += Vector3.right;

        // 이동 처리
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
