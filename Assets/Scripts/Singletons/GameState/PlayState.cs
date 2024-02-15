using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState: GameStateSingleton.IState
{
    public int score = 0;
    public bool isGameOver = false;


    public void Start()
    {
        SceneManager.LoadScene("Gameplay");
        Physics2D.simulationMode = SimulationMode2D.Update;
        Debug.Log("Play Start");

        PlayerStateSingleton.Instance.fire.Reset();
        PlayerStateSingleton.Instance.water.Reset();

        ScrollStateSingleton.Instance.Scroll = Vector2.zero;
        ScrollStateSingleton.Instance.SyncSmoothScroll();
    }

    private void UpdateScore()
    {
        GameObject spawner = GameObject.Find("Spawner");
        ChunkSpawner chunkSpawner = spawner.GetComponent<ChunkSpawner>();

        score = Mathf.Max(0, chunkSpawner.ChunkCount - 1);
    }
    private void UpdateGameOver()
    {
        // Escape hit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGameOver = true;
        }

        // Characters fell
        if (PlayerStateSingleton.Instance.fire.Position.y < -5 || PlayerStateSingleton.Instance.water.Position.y < -5)
        {
            isGameOver = true;
        }

        // Characters died
        if (PlayerStateSingleton.Instance.fire.IsDead || PlayerStateSingleton.Instance.water.IsDead)
        {
            isGameOver = true;
        }
    }

    public GameStateSingleton.IState Update()
    {
        UpdateGameOver();
        UpdateScore();
        if (isGameOver)
        {
            return new GameOverState(score);
        }

        TextMeshProUGUI scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = $"Score: {score}";

        return this;
    }

    public void Exit()
    {
        Debug.Log("Play Exit");
    }
}
