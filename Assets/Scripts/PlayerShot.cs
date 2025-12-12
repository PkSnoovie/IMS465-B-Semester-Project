using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 8.0f * Time.deltaTime);

        if (transform.position.y > 13.0f)
        {
            Destroy(gameObject);
        }
    }
}