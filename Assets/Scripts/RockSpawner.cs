using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    Timer timer;

    [SerializeField]
    GameObject[] prefabRock;

    const float SpawnTime = 1.0f;

    // Dimensions so that the rock only spawn witthin the screen
    const int SpawnBorderSize = 100;
    int minSpawnX = SpawnBorderSize;
    int minSpawnY = SpawnBorderSize;
    int maxSpawnX = Screen.width - SpawnBorderSize;
    int maxSpawnY = Screen.height - SpawnBorderSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = SpawnTime;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished && GameObject.FindGameObjectsWithTag("Rock").Length < 3)
        {
            SpawnRock();
            // No necesary
            // timer.Duration = SpawnTime;
            timer.Run();
        }
    }

    void SpawnRock()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        GameObject rock;
        int prefabNumber = Random.Range(0, 3);

        if (prefabNumber == 0)
        {
            rock = Instantiate<GameObject>(prefabRock[0], worldLocation, Quaternion.identity);
        }
        else if (prefabNumber == 1)
        {
            rock = Instantiate<GameObject>(prefabRock[1], worldLocation, Quaternion.identity);
        }
        else 
        {
            rock = Instantiate<GameObject>(prefabRock[2], worldLocation, Quaternion.identity);
        }

        rock.tag = "Rock";
    }
}
