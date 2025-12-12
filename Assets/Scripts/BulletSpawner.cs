using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    [SerializeField] private AudioClip shootSFX;

    private GameObject spawnedBullet;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin)
        {
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        }
        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
    }

    private void Fire()
    {
        if(bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<EnemyBullet>().speed = speed;
            spawnedBullet.GetComponent<EnemyBullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
            //SoundFXManager.instance.PlaySoundFXClip(shootSFX, transform, 0.7f, false);
        }
    }
}
