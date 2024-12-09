using UnityEngine;

public class GwaniMovement : MonoBehaviour
{
    public float speed = 5f; // ?��?�� ?��?��

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // ?��?��?�� ?�� ?��?�� 처리
       
        if (Input.GetKey(KeyCode.LeftArrow))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow))
            moveDirection += Vector3.right;

        // ?��?�� 처리
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
