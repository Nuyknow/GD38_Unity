using UnityEngine;

public class AssiserMove : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);


        

        // 바라보는 방향의 X 축 좌표를 얻습니다.
        Vector3 dcirection = target.position - transform.position;
        Vector3 lookDirection = new Vector3(dcirection.x, 0, 0).normalized;



        // 자신과 타겟의 거리가 0이 아닌 경우에만 동작합니다.
        if (lookDirection != Vector3.zero) // Vector3.zero는 (0,0,0)과 같습니다.
        {
            transform.right = lookDirection; // 객체의 위쪽 방향을 바라보는 방향으로 설정한다.
        }



        // lookDirection 방향으로 moveSpeed 속도로 이동한다.
        transform.position += lookDirection * moveSpeed * Time.deltaTime;
    }
}
