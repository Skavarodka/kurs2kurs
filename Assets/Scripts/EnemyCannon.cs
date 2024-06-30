using UnityEngine;
using UnityEngine.UIElements;

public class EnemyCannon : MonoBehaviour
{
    public GameObject EnemyBullet;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemy", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemy()
    {
        GameObject playerShip = GameObject.Find("Player");
        GameObject floor = GameObject.Find("floor");
        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            bullet.transform.position = transform.position;
            Vector2 direction = new Vector2((floor.transform.position ).x, (floor.transform.position - bullet.transform.position).y);
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
