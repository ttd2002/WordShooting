using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class WordRandom : WordAbstract
{
    [SerializeField] protected float spawnDelay = 3f;
    [SerializeField] protected float spawnTimer = 0; 
    public virtual void WordSpawning(string randomText,Vector3 spawnPos)
    {
        this.spawnTimer += Time.fixedDeltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0;

        Quaternion rot = transform.rotation;
        Transform obj = this.wordController.WordSpawner.Spawn(WordSpawner.textOne, spawnPos, rot);
        TextMeshPro textComponent = obj.gameObject.GetComponentInChildren<TextMeshPro>();
        textComponent.text = randomText;
        obj.gameObject.SetActive(true);
    }

    protected virtual bool GetParagraph()
    {
        int randomValue = Random.Range(0, 4);
        return randomValue == 0;
    }
}
