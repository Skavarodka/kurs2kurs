using UnityEngine;

public class Player : MonoBehaviour
{   
    public GameManager GameManager;
    public GameObject PlayerBullet;
    public GameObject bulletCannon;
    public float speed;
    const int MaxLives = 3;
    int lives;

    public void Init()
    {
        lives = MaxLives;
        gameObject.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            bullet.transform.position = bulletCannon.transform.position;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
     
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;
        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 position = transform.position;
        position += direction * speed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x,min.x, max.x);
        position.y = Mathf.Clamp(position.y,min.y, max.y);

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "EnemyTag") || (collision.tag =="EnemyBulletTag"))
        {
            lives--;
            if (lives == 0)
            {   
                GameManager.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
        }

    }
}
