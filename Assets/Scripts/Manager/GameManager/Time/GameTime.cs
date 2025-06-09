using Mono.Cecil;
using UnityEngine;

public class GameTime : Singleton<GameTime>
{
    private float _evenTime = 1f;
    private float _gameRunTime = 1f;
    private float _gameDeltaTime = 1f;
    private float resetGameRunTime = 0;
    private float resetEventTime = 0;
    /// <summary>
    /// Everything drop relatet like fall speed or attack times
    /// </summary>
    public float EventTime
    {
        set => _evenTime = Mathf.Clamp(value, 0, 2);
        get => _evenTime * _gameDeltaTime;
    }
    /// <summary>
    /// The Run time for everything game related like player movemend and spawn time
    /// </summary>
    public float GameRunTime
    {
        set => _gameRunTime = Mathf.Clamp(value, 0, 2);
        get => _gameRunTime * _gameDeltaTime;
    }
    /// <summary>
    /// The Ultimate time every other time is multiplied by
    /// </summary>
    public float GameDeltaTime
    {
        set => _gameDeltaTime = Mathf.Clamp(value, 0, 1);
        get => _gameDeltaTime;
    }

    public void SlowTimeDown(float newTimeValue, float forSeconds, E_Time timeToSlowDown)
    {
        if (timeToSlowDown == E_Time.Reset)
        {
            GameRunTime = 1;
            EventTime = 1;
            return;
        }

        if (timeToSlowDown == E_Time.GameRunTime)
        {
            resetGameRunTime += forSeconds;
            GameRunTime = newTimeValue;
            return;
        }

        if (timeToSlowDown == E_Time.EventTime)
        {
            resetEventTime += forSeconds;
            EventTime = newTimeValue;
            return;
        }
    }

    void Update()
    {
        if (GameDeltaTime == 0)
            return;
    
        if (resetEventTime > 0)
        {
            resetEventTime -= Time.deltaTime;

            if (resetEventTime <= 0)
            {
                EventTime = 1;
                resetEventTime = 0;
            }
        }

        if (resetGameRunTime > 0)
        {
            resetGameRunTime -= Time.deltaTime;

            if (resetGameRunTime <= 0)
            {
                GameRunTime = 1;
                resetGameRunTime = 0;
            }
        }
    }

}
