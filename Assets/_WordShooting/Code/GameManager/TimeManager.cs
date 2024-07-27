using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : WMonobehaviour
{
    private static TimeManager instance;
    public static TimeManager Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (TimeManager.instance != null) Debug.LogError("Only 1 TimeManager allow to exist");
        TimeManager.instance = this;
    }
    protected string gameDuration;
    public string GameDuration => gameDuration;
    [SerializeField] protected float remainingTime = 120f;
    protected bool gameEnded = false;
    protected virtual void FixedUpdate()
    {
        this.UpdateTime();
    }
    protected virtual void UpdateTime()
    {
        if (this.remainingTime > 0)
        {
            this.remainingTime -= Time.fixedDeltaTime;
        }
        else if (this.remainingTime < 0)
        {
            this.remainingTime = 0;
            this.EndGame();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        this.gameDuration = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public virtual void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
    }
}
