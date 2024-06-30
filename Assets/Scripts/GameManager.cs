using UnityEngine;



public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject gameOver;

    public enum GameManagerState
    {
        Opening,
        GamePlay,
        GameOver,
    }

    public GameManagerState state;

    public void Start()
    {
        state = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (state)
        {
            case GameManagerState.Opening:
                gameOver.SetActive(false);
                playButton.SetActive(true);
                break;

            case GameManagerState.GamePlay:
                playButton.SetActive(false);
                playerShip.GetComponent<Player>().Init();
                enemySpawner.GetComponent<EnemySpawner>().UpSpawner();
                break;

            case GameManagerState.GameOver:
                enemySpawner.GetComponent<EnemySpawner>().UnSpawner();
                gameOver.SetActive(true);
                Invoke("ChangeToOpeningState", 5f);
                break;
        }

    }

    public void SetGameManagerState(GameManagerState Gstate)
    {
        state = Gstate;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        state = GameManagerState.GamePlay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
