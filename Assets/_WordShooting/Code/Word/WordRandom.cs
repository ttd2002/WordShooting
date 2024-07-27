using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class WordRandom : WordAbstract
{
    [SerializeField] protected float spawnDelay = 3f;
    [SerializeField] protected float spawnTimer = 0; 
    public virtual void WordSpawning(WordModel wordModel)
    {
        this.spawnTimer += Time.fixedDeltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0;

        Quaternion rot = transform.rotation;
        Transform obj = this.wordController.WordSpawner.Spawn(WordSpawner.textOne, wordModel.GetSpawnPos(), rot);
        WordType wordType = obj.gameObject.GetComponentInChildren<WordType>();
        if (wordModel.GetIsSentence())
        {
            wordType.SetIsSentence();
        }
        else
        {
            wordType.SetIsWord();
        }
        TextMeshPro textComponent = obj.gameObject.GetComponentInChildren<TextMeshPro>();
        textComponent.text = wordModel.GetText();
        obj.gameObject.SetActive(true);
    }

}
