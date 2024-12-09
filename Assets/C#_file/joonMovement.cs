using UnityEngine;

public class GwaniMovement : MonoBehaviour
{
    public float speed = 5f; // ?ù¥?èô ?Üç?èÑ

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // ?ôî?Ç¥?ëú ?Ç§ ?ûÖ?†• Ï≤òÎ¶¨
       
        if (Input.GetKey(KeyCode.LeftArrow))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow))
            moveDirection += Vector3.right;

        // ?ù¥?èô Ï≤òÎ¶¨
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
