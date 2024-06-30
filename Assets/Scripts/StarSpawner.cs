
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject Star;
    public int MaxStar;
    Color[] starsColors =
    {
        new Color(0.5f, 0.5f, 1f),//BLUE
        new Color(0, 1f, 1f),//GREEN
        new Color(1f, 1f, 0),//YELLOW
        new Color(1f, 0, 0),//RED
    };
    
    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for (int i = 0; i < MaxStar; i++)
        {
            GameObject star = (GameObject) Instantiate(Star);
            star.GetComponent<SpriteRenderer>().color = starsColors[i%starsColors.Length];
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
