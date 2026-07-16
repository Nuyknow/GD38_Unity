using System.Diagnostics.Contracts;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        transform.position = Vector3.zero;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
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
