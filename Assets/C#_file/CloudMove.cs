using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 2f; // 구름 이동 속도
    public float startX = -10f; // 구름이 시작할 X 좌표
    public float endX = 10f; // 구름이 끝날 X 좌표

    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        // 시작 위치와 끝 위치를 설정
        startPosition = new Vector3(startX, transform.position.y, transform.position.z);
        endPosition = new Vector3(endX, transform.position.y, transform.position.z);

        // 구름을 시작 위치로 설정
        transform.position = startPosition;
    }

    void Update()
    {
        // 오른쪽으로 이동
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

        // 끝에 도달하면 다시 시작 위치로 이동
        if (transform.position == endPosition)
        {
            transform.position = startPosition;
        }
    }
}