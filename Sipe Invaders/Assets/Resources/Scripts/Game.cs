using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public const float UPPER_BOUNDARY = 4;
    public const float LOWER_BOUNDARY = -10;
    public const float LOWER_ENEMY_BOUNDARY = -2.5f;
    public const float LEFT_BOUNDARY = -4;
    public const float RIGHT_BOUNDARY = 4;

    static int score = 0;
    static int highScore = 0;
    static public int level = 1;
    static public Vector3 enemyPosition = new Vector3(0, 0, 0);
    static Vector3 playerPosition = new Vector3(0, -4.7f, 0);

    bool playerStatus;
    
    public int numEnemies;
    public int maxEnemies;

    GameObject player;
    ResetFlash flash;
   
    CanvasGroup Interface;
    CanvasGroup GameOverMenu;

    void Start()
    {

        Interface = GameObject.FindWithTag("Interface").GetComponent<CanvasGroup>();
        GameOverMenu = GameObject.FindWithTag("Game Over Menu").GetComponent<CanvasGroup>();

        // Create Player
        player = (GameObject)Instantiate(Resources.Load("Prefabs\\Player"), playerPosition, Quaternion.identity);
        playerStatus = true;

        flash = FindObjectOfType<ResetFlash>();

        // Create enemies
        for (int i = 0; i < level; i++){
            GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs\\Raylien"), enemyPosition, Quaternion.identity);
        }
        
        numEnemies = level;
        maxEnemies = level;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !playerStatus)
            ResetGame();
    }

    public void NextLevel()
    {
        flash.FlashColour();

        playerPosition = player.transform.position;
        Destroy(player);

        level++;
        SceneManager.LoadScene("game");
        Start();
    }

    public void ResetGame()
    {
        level = 1;
        score = 0;
        Enemy.speed = 3.5f;
        enemyPosition = new Vector3(0, 0, 0);
        playerPosition = new Vector3(0, -4.7f, 0);
        Destroy(player);
        SceneManager.LoadScene("game");
        Start();
    }

    public void GameOver()
    {
        Interface.alpha = 0;
        GameOverMenu.alpha = 1;

        playerStatus = false;        
    }

    public int GameScore
    {
        get { return score; }
        set
        {
            score = value;
            GameHighScore = score;
        }
    }

    public int GameHighScore
    {
        get { return highScore; }
        set
        {
            if (value > highScore)
                highScore = value;
        }
    }
}
