using UnityEngine;

public class ElevationTransition : MonoBehaviour
{
    [SerializeField] GameObject currentCollision;
    [SerializeField] GameObject nextCollision;
    [SerializeField] SpriteRenderer playerRenderer;
    [SerializeField] string nextSortingLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        currentCollision.SetActive(false);
        nextCollision.SetActive(true);
        playerRenderer.sortingLayerName = nextSortingLayer;
    }
}
