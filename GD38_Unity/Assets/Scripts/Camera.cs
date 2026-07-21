using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField, Min(0.01f)] float smoothTime = 0.2f;
    Vector3 smoothVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref smoothVelocity, smoothTime);
    }
}
