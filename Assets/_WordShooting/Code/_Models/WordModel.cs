using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordModel
{
    private string text { get; set; }
    private Vector3 spawnPos {  get; set; }
    private bool isSentence {  get; set; }
    public WordModel(string text, Vector3 spawnPos, bool isSentence)
    {
        this.text = text;
        this.spawnPos = spawnPos;
        this.isSentence = isSentence;
    }
    public WordModel()
    {
        
    }
    public string GetText()
    {
        return this.text;
    }

    public void SetText(string text)
    {
        this.text = text;
    }
    public Vector3 GetSpawnPos()
    {
        return this.spawnPos;
    }
    public void SetSpawnPos(Vector3 spawnPos)
    {
        this.spawnPos = spawnPos;
    }
    public bool GetIsSentence()
    {
        return this.isSentence;
    }
    public void SetIsSentences(bool isSentence)
    {
        this.isSentence = isSentence;
    }

}
