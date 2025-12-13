using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            StartGame();
        }
        if (SceneManager.GetActiveScene().name == "StartMenu" && Player.lives <= 0 || SceneManager.GetActiveScene().name == "StartMenu" && Enemy.health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
        }
        
    }

    public void StartGame()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TheGame");
            GameManager.gameOver = false;
        }
    }

    public void EndGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}