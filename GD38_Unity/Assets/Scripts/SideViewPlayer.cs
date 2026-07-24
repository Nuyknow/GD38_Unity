using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class SideViewPlayer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Vector2 moveInput;
    
    Rigidbody2D rigid;




    [SerializeField] float groundCheckDistance = 0.05f; // 바닥을 확인하기 위한 거리
    [SerializeField] LayerMask groundLayer; // 바닥을 구분하기 위한 Layer
    Collider2D bodyCollider; // Collider2D는 CapsuleCollider2D의 부모 타입으로 모두 받아올 수 있음





    // [속성]
    // 이동 속도
    [SerializeField] float moveSpeed;
    Vector2 moveDirection;


    // 점프 강도
    [SerializeField] float jumpPower;
    [SerializeField] float coyoteTime = 0.1f;

    float coyoteTimeCounter; // 코요테 타임 남은 시간
    bool isJumping; // 점프 중인지 확인

    // [행동]
    private void Awake()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        // rigid = 본 객체(this)의 Rigidbody2D 컴포넌트를 얻는(GetComponent) 함수를 실행(())한다.

        spriteRenderer = this.GetComponent<SpriteRenderer>();

        bodyCollider = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        move();
    }




    // 이동
    void move()
    {
        rigid.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rigid.linearVelocity.y);
        // 물리 컴포넌트.속도 =             (   x축 입력값   *  이동 속도,      y의 기존 속도     );
    }

    // 점프
    void Jump()
    {
        rigid.AddForceY(jumpPower);
    }

    // Input System에서 입력받은 값을 적용
    void OnMove(InputValue _value)
    {
        moveDirection = _value.Get<Vector2>();
        // 이동 방향 = 입력한 값에서 Vector2 타입의 값을 Get하는 함수를 실행한다.

        moveInput = _value.Get<Vector2>();

        if (moveInput.x != 0f)
        {
            spriteRenderer.flipX = moveInput.x < 0f;
        }
    }


    void OnJump()
    {
        isJumping = true; // 점프중 : true

        rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, 0f); // Y 이동값을 0으로 초기화 합니다.
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        if (coyoteTimeCounter <= 0f) return; // 코요테 타임이 남아 있지 않다면 점프하지 않습니다.

        coyoteTimeCounter = 0f; // 점프를 사용했으므로 코요테 타임을 비웁니다.
    }

    bool IsGrounded()
{
    Bounds bounds = bodyCollider.bounds; // 콜라이더의 범위

    Vector2 origin = new Vector2(bounds.center.x, bounds.min.y); // 중앙 하단을 기준으로 합니다.
    Vector2 size = new Vector2(bounds.size.x * 0.9f, 0.05f);

    RaycastHit2D hit = Physics2D.BoxCast(origin, size, 0f, Vector2.down, groundCheckDistance, groundLayer);

    return hit.collider != null;
}






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            bool isGrounded = IsGrounded(); // 땅에 닿았는지 확인합니다.

            if (isGrounded == true && isJumping == false) // 땅에 닿은 상태이며 점프 직후 상태가 아니라면, 코요테 타임을 채웁니다.
            {
                coyoteTimeCounter = coyoteTime;
            }
            else // 땅이 아니거나, 점프 상태라면 코요테 타임을 감소시킵니다.
            {
                coyoteTimeCounter -= Time.deltaTime;
            }

            if (isGrounded == false) // 바닥 판정 범위를 벗어나면 점프 직후 상태를 해제합니다.
            {
                isJumping = false;
            }
        }
    }
}
