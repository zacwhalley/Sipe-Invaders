using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public const float UPPER_BOUNDARY = 4;
    public const float LOWER_BOUNDARY = -10;
    public const float LOWER_ENEMY_BOUNDARY = -2.5f;
    public const float LEFT_BOUNDARY = -4;
    public const float RIGHT_BOUNDARY = 4;

    static public int score = 0;
    static public int level = 1;

    public int numEnemies;
    public int maxEnemies;

    GameObject player;
    
    void Start()
    {
        numEnemies = level;
        maxEnemies = level;

        // Create Player
        player = (GameObject)Instantiate(Resources.Load("Prefabs\\Player"), new Vector3(0, -4.7f, 0), Quaternion.identity);

        // Create enemies
        for (int i = 0; i < level; i++)
        {
            GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs\\Raylien"), new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void Reset()
    {
        Debug.Log("Game Reset");
        level++;
        Destroy(player);
        Start();
    }
}
