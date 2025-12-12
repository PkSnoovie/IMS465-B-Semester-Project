using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 1000;
    public int maxHealth = 1000;
    //public float speed = 4f;
    private float timer = 0f;

    public float frequency = 2f;
    public float magnitude = 7.5f;
    public float offset = 0f;
    public int currPhase = 0;
    private Vector3 spawnPosition;

    public HealthBar healthBar;
    //public string direction = "right";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (currPhase == 0)
        {
            transform.position = spawnPosition + transform.right * Mathf.Sin(Time.time * frequency + offset) * magnitude;
            /*if (transform.position.x < 2f) //left boundary
            {
                direction = "right";
            } else if (transform.position.x > 15f)
            {
                direction = "left";
            }*/
        } else if (currPhase == 1)
        {
            frequency = 10f;
            transform.position = spawnPosition + transform.right * Mathf.Sin(Time.time * 20f + offset) * magnitude;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Knows its Bullet");
            Destroy(collision.gameObject);
            if (health >= 1)
            {
                health -= 1;
                healthBar.SetHealth(health);
                Debug.Log("Health -1");
            } 
            else if (health < 1)
            {
                Destroy(gameObject);
                Debug.Log("Enemy dies");
            }
        }
    }

    /*private Vector2 moveEnemy(string direction, float timer)
    {
        if (direction == "right")
        {
            float x = timer * speed * transform.right.x;
            float y = timer * speed * transform.right.y;
            return new Vector2(x + spawnPosition.x, y + spawnPosition.y);
        } else if (direction == "left")
        {
            float x = timer * -speed * transform.right.x;
            float y = timer * speed * transform.right.y;
            return new Vector2(x + spawnPosition.x, y + spawnPosition.y);
        }
        return new Vector2(transform.position.x, transform.position.y);
        
    }*/
}
