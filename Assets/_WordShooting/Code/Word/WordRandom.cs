using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class WordRandom : WMonobehaviour
{
    [SerializeField] protected WordCtrl wordCtrl;
    [SerializeField] protected float spawnTime = 3f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWordCtrl();
    }

    protected virtual void LoadWordCtrl()
    {
        if (this.wordCtrl != null) return;
        this.wordCtrl = GetComponent<WordCtrl>();
        Debug.Log(transform.name + ": LoadWordCtrl", gameObject);
    }


    protected override void Start()
    {
        this.StartCoroutine(FetchRandomWordsAndUseThem());
        this.WordSpawning();
    }
    protected virtual IEnumerator FetchRandomWordsAndUseThem()
    {
        yield return wordCtrl.RandomWordFetcher.FetchRandomWordsAndParagraphsOnce(OnRandomWordsReceived, OnParagraphsReceived, 100);

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
    protected virtual void WordSpawning()
    {
        Transform ranPoint = this.wordCtrl.SpawnPoint.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.wordCtrl.WordSpawner.Spawn(WordSpawner.textOne, pos, rot);
        string randomText;
        if (GetParagraph())
        {
            randomText = wordCtrl.RandomWordFetcher.GetRandomParagraph();
        }
        else
        {
            randomText = wordCtrl.RandomWordFetcher.GetRandomWord();
        }
        TextMeshPro textComponent = obj.gameObject.GetComponentInChildren<TextMeshPro>();
        textComponent.text = randomText;
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.WordSpawning), spawnTime);
    }

    protected virtual bool GetParagraph()
    {
        int randomValue = Random.Range(0, 4);
        return randomValue == 0;
    }
}
