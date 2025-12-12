using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float focusSpeed;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject HitBox;
    private bool focusMode = false;
    Vector2 playerMovement;

    void Start()
    {
        transform.position = new Vector3(5f, 5f, 0);
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
            Instantiate(Bullet, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
        }
    }

    void NormalMode()
    {
        transform.Translate(playerMovement * moveSpeed * Time.deltaTime);
        HitBox.GetComponent<SpriteRenderer>().enabled = false;
    }

    void FocusMode()
    {
        transform.Translate(playerMovement * focusSpeed * Time.deltaTime);
        HitBox.GetComponent<SpriteRenderer>().enabled = true;
    }
}
