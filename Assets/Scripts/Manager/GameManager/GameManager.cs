using UnityEngine;
using PoketAPI.Touch;
using UnityEngine.Events;
using System;
using System.Collections;
public class GameManager : MonoBehaviour, I_Manager
{
    [HideInInspector] public GameObject player;
    private int _score = 0;
    public int Score
    {
        get => _score;
        set
        {
            if (allowScore)
            {
                _score += (value - _score) * ScoreMultiplier;
            }
        }
    }
    private int _scoreMultiplier = 1;
    public int ScoreMultiplier
    {
        get => _scoreMultiplier;
        set
        {
            _scoreMultiplier = Mathf.Clamp(value, 1, 10);
        }
    }
    [SerializeField] private UnityEvent gameStartEvents;
    [SerializeField] private UnityEvent gamePauseEvents;
    [SerializeField] private UnityEvent gameUnPauseEvents;
    [SerializeField] private UnityEvent gameEndEvents;
    private bool gameStarted = false;
    public bool CanStartGame { set; get; } = true;
    private bool pause = false;
    private B_player b_Player;
    private GameObject oldPlayer;
    private bool allowScore;
    private bool _playerDied = false;

    public bool PlayerDied
    {
        get => _playerDied;
        private set{}
    }

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (!gameStarted)
            GameStartCondition();
        else
            ControllPlayerStats();

    }

    private void ControllPlayerStats()
    {
        if (player == null)
            return;

        if (b_Player == null || player != oldPlayer)
        {
            oldPlayer = player;
            b_Player = player.GetComponent<B_player>();
        }

        if (b_Player.PlayerHealth > 0)
            return;

        allowScore = false;
        _playerDied = true;
        GameTime.Instance.GameDeltaTime = 0.3f;

        if(GetTab.DoubleTab())
        {
            GameEnd();
        }

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
        allowScore = true;
        _playerDied = false;
        gameStartEvents.Invoke();
    }

    public void GameEnd()
    {
        GameTime.Instance.GameDeltaTime = 1;
        ScoreMultiplier = 1;
        _score = 0;

        _playerDied = false;

        StartCoroutine(WaitForAllowGameRestart());

        gameEndEvents.Invoke();
        b_Player.ResetPlayer();
    }
    IEnumerator WaitForAllowGameRestart()
    {
        yield return new WaitForSeconds(1f);
        gameStarted = false;

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
        allowScore = false;
        gamePauseEvents.Invoke();
        GameTime.Instance.GameDeltaTime = 0;
        pause = true;
    }

    public void UnPauseGame()
    {
        allowScore = true;
        gameUnPauseEvents.Invoke();
        GameTime.Instance.GameDeltaTime = 1;
        pause = false;
    }
}
