using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    bool ready;

    void Awake()
    {
        speed = 5f;
        ready = false;
    }
    void Start()
    {
        
    }

    public void SetDirection(Vector2 direction1)
    {
        direction = direction1.normalized;
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            Vector2 position = transform.position;
            position += direction * speed * Time.deltaTime;
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            if (transform.position.y < min.y)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
