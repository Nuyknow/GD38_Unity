using System;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterMove_Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 180f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 타겟까지의 방향을 설정합니다.
        Vector3 direction = (target.position - transform.position).normalized;

        // 바라볼 목표 회전값 계산하기
        // Quaternion.FromToRotations는 타겟 방향으로 회전시키려면 얼마나 회전해야 하는지 계산해 주는 함수입니다.
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, direction);

        // 현재 각도에서 목표 각도까지 rotateSpeed 속도로 회전합니다.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        // 바라보는 방향으로 moveSpeed만큼 이동합니다.
        // 'rotateSpeed'는 1초 동안 회전할 수 있는 각도입니다. 
        // 값이 크면 목표 방향으로 빠르게 회전하고, 값이 작으면 넓게 휘어지며 이동합니다.
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
