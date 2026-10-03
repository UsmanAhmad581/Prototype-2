using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{   private float topBound = 40.0f;
    private float lowerBound = -10.0f;
    private float leftBound = -32.0f;
    private float rightBound = 32.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
        
}
