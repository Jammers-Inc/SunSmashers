using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState State;
    public States status;
    private void OnEnable()
    {
        State = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDisable()
    {
        State = null;
    }

    public void StartGame()
    {
        status = States.start;
    }

    public void StartPlay()
    {
        status = States.play;
    }

    public void Win()
    {
        status = States.finished;
    }

    public enum States
    {
        start, play, finished
    }
}
