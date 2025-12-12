using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer = 0f;
    [SerializeField] public Enemy bossEnemy;
    [SerializeField] public AudioClip bgm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundFXManager.instance.PlaySoundFXClip(bgm, transform, 0.9f, true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer >= 5)
        {
            bossEnemy.currPhase = 1;
        }
    }
}
