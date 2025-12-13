using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBullet : MonoBehaviour
{
    private Vector2 spawnPosition;

    public float bulletLife = 1f;
    public float rotation = 0f;
    public float speed = 1f;
    private float timer = 0f;
    [SerializeField] private AudioClip shootSFX;
    [SerializeField] private Player P;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPosition = new Vector2(transform.position.x, transform.position.y);
        SoundFXManager.instance.PlaySoundFXClip(shootSFX, transform, 0.7f, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife)
        {
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
        transform.position = moveBullet(timer);
    }

    private Vector2 moveBullet(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPosition.x, y + spawnPosition.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHitBox"))
        {
            if(P != null)
            {
                P.Damage();
            }
            //Destroy(collision.transform.parent.gameObject);
            //Debug.Log("Bullet collides with player");
        }
    }
}
