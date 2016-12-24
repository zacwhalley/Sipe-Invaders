using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public const float UPPER_BOUNDARY = 4;
    public const float LOWER_BOUNDARY = -10;
    public const float LOWER_ENEMY_BOUNDARY = -2.5f;
    public const float LEFT_BOUNDARY = -4;
    public const float RIGHT_BOUNDARY = 4;

    static public int score = 0;
    static public int level = 1;
    static public Vector3 enemyPosition = new Vector3(0, 0, 0);
    static Vector3 playerPosition = new Vector3(0, -4.7f, 0);
    
    public int numEnemies;
    public int maxEnemies;

    GameObject player;
    ResetFlash flash;

    void Start()
    {
        // Create Player
        player = (GameObject)Instantiate(Resources.Load("Prefabs\\Player"), playerPosition, Quaternion.identity);
        flash = FindObjectOfType<ResetFlash>();

        // Create enemies
        for (int i = 0; i < level; i++)
        {
            GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs\\Raylien"), enemyPosition, Quaternion.identity);
        }
        numEnemies = level;
        maxEnemies = level;
    }

    public void Reset()
    {
        flash.FlashColour();

        playerPosition = player.transform.position;
        Destroy(player);

        level++;
        SceneManager.LoadScene("game");
        Start();
    }
}
