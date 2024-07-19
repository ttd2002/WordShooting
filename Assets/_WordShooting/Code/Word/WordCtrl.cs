using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCtrl : WMonobehaviour
{
    [SerializeField] protected WordSpawner wordSpawner;
    public WordSpawner WordSpawner { get => wordSpawner; }

    [SerializeField] protected WordSpawnPoints spawnPoint;
    public WordSpawnPoints SpawnPoint { get => spawnPoint; }
    [SerializeField] protected RandomWordFetcher randomWordFetcher;
    public RandomWordFetcher RandomWordFetcher { get => randomWordFetcher; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWordCtrl();
        this.LoadSpawnPoint();
        this.LoadRandomWordFetcher();

    }

    protected virtual void LoadWordCtrl()
    {
        if (this.wordSpawner != null) return;
        this.wordSpawner = GetComponent<WordSpawner>();
        Debug.Log(transform.name + ": LoadWordCtrl", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = Transform.FindObjectOfType<WordSpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }
    protected virtual void LoadRandomWordFetcher()
    {
        if (this.randomWordFetcher != null) return;
        this.randomWordFetcher = Transform.FindObjectOfType<RandomWordFetcher>();
        Debug.Log(transform.name + ": LoadRandomWordFetcher", gameObject);
    }
}
