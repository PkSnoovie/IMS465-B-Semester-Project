using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer = 0f;
    [SerializeField] public Enemy bossEnemy;
    [SerializeField] public GameObject player;
    [SerializeField] public AudioClip bgm;
    public SceneController sc;
    //[SerializeField] private GameObject Player = null;
    private bool paused = false;
    public static bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundFXManager.instance.PlaySoundFXClip(bgm, transform, 0.9f, true);
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == false)
            {
                //pause the game
                Time.timeScale = 0; //0% of fps
                paused = true;
            }
            else
            {
                //resume the game
                Time.timeScale = 1; //100% of fps
                paused = false;
            }
        }
        
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer >= 20 || Enemy.health <= 3000)
        {
            if (Enemy.health <= 2000)
            {
                if (Enemy.health <= 1000)
                {
                    bossEnemy.currPhase = 3;
                    Debug.Log("Curernt Phase: " + bossEnemy.currPhase);
                }
                bossEnemy.currPhase = 2;
                Debug.Log("Curernt Phase: " + bossEnemy.currPhase);
            }
            bossEnemy.currPhase = 1;
            Debug.Log("Curernt Phase: " + bossEnemy.currPhase);
        }

        

        if(gameOver == true)
        {
            sc.EndGame();
        }
    }
}
