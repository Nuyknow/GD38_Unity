using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // 캐릭터 이동 속도

    Vector2 moveInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 입력 값이 0 이 아닐 때만 이동 처리
        if (moveInput != Vector2.zero)
        {
            // Vector2 입력을 Vector3로 변환하여 position에 더해줍니다.
            Vector3 moveDirection = new Vector3(moveInput.x, moveInput.y, 0f);


            if (moveDirection.x != 0)
            {
                spriteRenderer.flipX = moveDirection.x < 0f;
            }
        }
    }

    // Send Messages 방식으로 호출되는 이동 이벤트 함수
    // Action이름 앞에 On을 붙여 Action과 연결
    // (InputValue _value) 매개변수로 InputValue를 받아옴

    void OnMove(InputValue _value)
    {
        moveInput = _value.Get<Vector2>(); // 매개변수로 받아온 _value 의 Vector2를 moveInput에 넣음
    }

    void FixedUpdate()
    {
        rigid.linearVelocity = moveInput * moveSpeed; // 이동은 Rigidbody2D의 속도로 처리합니다.
    }



}
