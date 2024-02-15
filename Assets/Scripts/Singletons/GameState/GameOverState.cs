using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState: GameStateSingleton.IState
{
    public int Score;

    public GameOverState(int score)
    {
        Score = score;
    }

    public void Start()
    {
        
        Debug.Log("GameOver Starting...");

        Physics2D.simulationMode = SimulationMode2D.Script;
        Debug.Log("Stopped physics");

        Camera camera = Camera.main;
        int children = camera.transform.childCount;
        GameObject canvas = camera.transform.GetChild(children - 1).gameObject;
        GameObject gameOverTextGroup = canvas.transform.Find("GameOverText").gameObject;
        gameOverTextGroup.SetActive(true);
        Debug.Log("Activated GameOverText");

        TextMeshProUGUI text = gameOverTextGroup.GetComponentInChildren<TextMeshProUGUI>();
        text.text = $"Game Over :(\n{Score} points\nPress Space to restart\nPress Escape to quit";
        Debug.Log("Set GameOverText text");

        GameObject fireBoy = GameObject.Find("FireBoy");
        GameObject waterGirl = GameObject.Find("WaterGirl");

        foreach (AnimationManager am in fireBoy.GetComponentsInChildren<AnimationManager>())
        {
            am.enabled = false;
        }
        foreach (AnimationManager am in waterGirl.GetComponentsInChildren<AnimationManager>())
        {
            am.enabled = false;
        }
    }

    public GameStateSingleton.IState Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return new PlayState();
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            return new ExitState(this);
        } else
        {
            return this;
        }
    }

    public void Exit()
    {
        Debug.Log("GameOver Exit");
    }
}
