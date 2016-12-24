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
    static Vector3 playerPosition = new Vector3(0, -4.7f, 0);
    static Vector3 playerVelocity = new Vector3(0, 0, 0);

    public int numEnemies;
    public int maxEnemies;

    GameObject player;

    void Start()
    {
        // Create Player
        player = (GameObject)Instantiate(Resources.Load("Prefabs\\Player"), playerPosition, Quaternion.identity);
        player.GetComponent<Rigidbody2D>().velocity = playerVelocity;

        // Create enemies
        for (int i = 0; i < level; i++)
        {
            GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs\\Raylien"), new Vector3(0, 0, 0), Quaternion.identity);
        }
        numEnemies = level;
        maxEnemies = level;
    }

    public void Reset()
    {
        playerPosition = player.transform.position;
        playerVelocity = player.GetComponent<Rigidbody2D>().velocity;
        Destroy(player);

        level++;
        SceneManager.LoadScene("game");
        Start();
    }
}
