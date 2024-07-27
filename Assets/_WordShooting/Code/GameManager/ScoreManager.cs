using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : WMonobehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (ScoreManager.instance != null) Debug.LogError("Only 1 ScoreManager allow to exist");
        ScoreManager.instance = this;
    }
    protected int wordScore = 5;
    protected int sentenceScore = 10;
    [SerializeField] protected int totalScore = 0;
    public int TotalScore => totalScore;

    public virtual void AddWordScore()
    {
        this.totalScore += this.wordScore;
    }

    public virtual void AddSentenceScore()
    {
        this.totalScore += this.sentenceScore;
    }
}
