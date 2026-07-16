using UnityEngine;

public class LifeCycleTest : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake에서 호출됨.");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable: 활성화 시 호출됨.");

        // 현재 HP를 이번 스폰의 최대 HP로 설정합니다.
        // 몬스터가 스폰되어야 할 위치를 설정합니다.
        // 몬스터를 살아 있는 상태로 변경합니다.
        // 몬스터의 등장 효과를 재생합니다.

        // 스테이지가 5분이 지날 때마다 체력이 20% 증가된 몬스터가 나온다.
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start에서 호출됨.");

        // Player 오브젝트를 찾아 추적 대상으로 저장합니다.
        // 몬스터의 기본 이동 속도와 공격 범위를 불러옵니다.
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update: 매 프레임마다 호출됨.");

        // Player가 있는 방향을 계산합니다.
        // Player를 향해 몬스터를 이동시킵니다.
        // Player가 공격 범위 안에 있는지 확인합니다.
        // HP가 0 이하인지 확인합니다.
        // 사망하면 경험치 보석을 생성하고 몬스터를 비활성화합니다.

        // 보스 몬스터가 나타나면 일반 몬스터는 사라진다.
    }

    void OnDisable()
    {
        Debug.Log("OnDisable: 비활성화 시 호출됨.");
    }
}
