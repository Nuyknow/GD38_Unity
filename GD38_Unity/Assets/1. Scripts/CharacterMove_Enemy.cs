using System;
using TMPro;
using UnityEngine;

public class CharacterMove_Enemy : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);

        Vector3 direction = (targetTransform.position - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            transform.right = direction;
        }
    }
}
