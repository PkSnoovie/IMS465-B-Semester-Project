using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float focusSpeed;
    [SerializeField] private GameObject[] Bullets;
    private GameObject currBullets;
    [SerializeField] private GameObject HitBox;
    public static int lives = 3;
    public int maxLives = 3;
    private bool focusMode = false;
    Vector2 playerMovement;

    [SerializeField] public GameManager GM;
    [SerializeField] public AudioClip damageSFX;

    public HealthBar healthBar;
    //private SpriteRenderer healthBarSprite;

    void Start()
    {
        transform.position = new Vector3(5f, 5f, 0);
        lives = maxLives;
        healthBar.SetMaxHealth(maxLives);
        //healthBarSprite = playerHealthBar.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
        Boundaries();
        Shoot();
    }

    private void FixedUpdate()
    {
        if (focusMode == false)
        {
            NormalMode();
        }

        if (focusMode == true)
        {
            FocusMode();
        }
    }

    private void Movement()
    {
        playerMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            focusMode = true;
        }
        else
        {
            focusMode = false;
        }

    }

    private void Boundaries()
    {
        if (transform.position.y > 10f) //top boundary
        {
            transform.position = new Vector3(transform.position.x, 10f, 0);
        }

        else if (transform.position.y < 0) //bottom boundary
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (transform.position.x < 0) //left boundary
        {
            transform.position = new Vector3(0, transform.position.y, 0);

        }

        else if (transform.position.x > 17.79f) //right boundary
        {
            transform.position = new Vector3(17.79f, transform.position.y, 0);
        }
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Instantiate(Bullets[1], transform.position + new Vector3(0.25f, 0.75f, 0), Quaternion.identity);
            } else 
            {
                Instantiate(Bullets[0], transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
            }
            
        }
    }

    void NormalMode()
    {
        transform.Translate(playerMovement * moveSpeed * Time.deltaTime);
        HitBox.GetComponent<SpriteRenderer>().enabled = false;
        currBullets = Bullets[0];
    }

    void FocusMode()
    {
        transform.Translate(playerMovement * focusSpeed * Time.deltaTime);
        HitBox.GetComponent<SpriteRenderer>().enabled = true;
        currBullets = Bullets[1];
    }

    public void Damage()
    {
        lives--;
        //healthBar.SetHealth(lives);
        SoundFXManager.instance.PlaySoundFXClip(damageSFX, transform, 0.7f, false);
        Debug.Log("Current Lives is" + lives);

        /*if (lives >= 3)
        {
            playerHealthBar.GetComponent<SpriteRenderer>().sprite = healthImages[3];
        } else if (lives == 2)
        {
            playerHealthBar.GetComponent<SpriteRenderer>().sprite = healthImages[2];
        } else if (lives == 1)
        {
            playerHealthBar.GetComponent<SpriteRenderer>().sprite = healthImages[1];
        }*/

        if (lives < 1)
        {
            Debug.Log("GAME OVER");
            GameManager.gameOver = true;
        }
    }
}
