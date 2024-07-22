using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : WMonobehaviour
{
    [SerializeField] protected WordSpawner wordSpawner;
    public WordSpawner WordSpawner { get => wordSpawner; }

    [SerializeField] protected WordSpawnPoints spawnPoint;
    public WordSpawnPoints SpawnPoint { get => spawnPoint; }

    [SerializeField] protected RandomWordFetcher randomWordFetcher;
    public RandomWordFetcher RandomWordFetcher { get => randomWordFetcher; }

    [SerializeField] protected WordRandom wordRandom;
    public WordRandom WordRandom { get => wordRandom; }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(this.FetchRandomWordsAndUseThem());
    }

    protected virtual void FixedUpdate()
    {
        WordModel wordModel = GetWordModel();
        this.wordRandom.WordSpawning(wordModel.GetText(), wordModel.GetSpawnPos());
    }

    protected virtual WordModel GetWordModel()
    {
        string randomText = GetParagraph() ? this.randomWordFetcher.GetRandomParagraph() : this.randomWordFetcher.GetRandomWord();
        Vector3 spawnPos = this.spawnPoint.GetRandom().position;
        return new WordModel(randomText, spawnPos);
    }

    protected virtual bool GetParagraph()
    {
        int randomValue = Random.Range(0, 4);
        return randomValue == 0;
    }

    protected virtual IEnumerator FetchRandomWordsAndUseThem()
    {
        yield return this.randomWordFetcher.FetchRandomWordsAndParagraphsOnce(OnRandomWordsReceived, OnParagraphsReceived, 100);
    }

    protected virtual void OnRandomWordsReceived(string[] words)
    {
        if (words == null) return;
        Debug.Log("Fetched " + words.Length + " random words.");
    }

    protected virtual void OnParagraphsReceived(List<string> paragraphs)
    {
        if (paragraphs == null) return;
        Debug.Log("Fetched " + paragraphs.Count + " paragraphs.");
    }

    // Load components
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWordSpawner();
        this.LoadSpawnPoint();
        this.LoadRandomWordFetcher();
        this.LoadWordRandom();
    }

    protected virtual void LoadWordSpawner()
    {
        if (this.wordSpawner != null) return;
        this.wordSpawner = GetComponent<WordSpawner>();
        Debug.Log(transform.name + ": LoadWordSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = FindObjectOfType<WordSpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }

    protected virtual void LoadRandomWordFetcher()
    {
        if (this.randomWordFetcher != null) return;
        this.randomWordFetcher = FindObjectOfType<RandomWordFetcher>();
        Debug.Log(transform.name + ": LoadRandomWordFetcher", gameObject);
    }

    protected virtual void LoadWordRandom()
    {
        if (this.wordRandom != null) return;
        this.wordRandom = FindObjectOfType<WordRandom>();
        Debug.Log(transform.name + ": LoadWordRandom", gameObject);
    }
}
