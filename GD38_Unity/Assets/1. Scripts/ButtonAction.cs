using System.Diagnostics.Contracts;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
        // 오브젝트의 위치를 x + 1 만큼 이동시킨다.
    }
    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
    }
    public void MoveUp()
    {
        transform.position += new Vector3(0, 1, 0);
    }
    public void MoveDown()
    {
        transform.position += new Vector3(0, -1, 0);
    }
}
