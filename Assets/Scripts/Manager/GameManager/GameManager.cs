using UnityEngine;
using PoketAPI.Touch;
using UnityEngine.Events;
public class GameManager : MonoBehaviour,I_Manager
{
    [HideInInspector] public GameObject player;
    [SerializeField] private UnityEvent gameStartEvents;
    [SerializeField] private UnityEvent gamePauseEvents;
    [SerializeField] private UnityEvent gameUnPauseEvents;
    [SerializeField] private UnityEvent gameEndEvents;
    private bool gameStarted = false;
    public bool CanStartGame { set; get; } = true;
    private bool pause = false;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (!gameStarted)
            GameStartCondition();
    }

    private void GameStartCondition()
    {
        if (!GetTab.DoubleTab())
        {
            return;
        }

        if (!CanStartGame)
        {
            return;
        }

        GameStart();
    }
   

    public void GameStart()
    {
        gameStarted = true;
        gameStartEvents.Invoke();
    }

    public void GameEnd()
    {
        gameEndEvents.Invoke();
    }
    public void DecidePauseAction()
    {
        if (!pause)
            PauseGame();
        else
            UnPauseGame();
    }
    public void PauseGame()
    {
        gamePauseEvents.Invoke();

        GameTime.Instance.GameDeltaTime = 0;

        pause = true;
    }

    public void UnPauseGame()
    {
        gameUnPauseEvents.Invoke();

        GameTime.Instance.GameDeltaTime = 1;

        pause = false;
    }
}
