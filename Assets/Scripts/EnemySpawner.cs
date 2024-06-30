using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawner()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        GameObject enemySp = (GameObject)Instantiate(enemy);
        enemySp.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        NextSpawn();

    }

    void NextSpawn()
    {
        float spawnInSecond;
        if (spawnSpeed > 1f)
        {
            spawnInSecond = Random.Range(spawnSpeed, 1f);
        } else
        {
            spawnInSecond = 1f;
        }
        Invoke("Spawner", spawnInSecond);
    }
    
    public void UpSpawner()
    {
        Invoke("Spawner", spawnSpeed);
    }
    public void UnSpawner()
    {
        CancelInvoke("Spawner");   
    }
}
