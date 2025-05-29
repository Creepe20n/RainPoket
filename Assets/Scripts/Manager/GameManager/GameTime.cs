using UnityEngine;

public class GameTime : Singleton<GameTime>
{
    private float _evenTime = 1f;
    private float _gameRunTime = 1f;
    private float _gameDeltaTime = 1f;
    public float EventTime//Everything drop relatet like fall speed or attack times
    {
        set => _evenTime = Mathf.Clamp(value, 0, 2);
        get => _evenTime * _gameDeltaTime;
    }
    public float GameRunTime//The Run time for everything game related like player movemend and spawn time;
    {
        set => _gameRunTime = Mathf.Clamp(value, 0, 2);
        get => _gameRunTime * _gameDeltaTime;
    }
    
    public float GameDeltaTime//The Ultimate time every other time is multiplied by
    {
        set => _gameDeltaTime = Mathf.Clamp(value, 0, 1);
        get => _gameDeltaTime;
    }

}
