using UnityEngine;

public class WordSpawner : Spawner
{
    private static WordSpawner instance;
    public static WordSpawner Instance { get => instance; }

    public static string textOne = "Text_1";

    protected override void Awake()
    {
        base.Awake();
        if (WordSpawner.instance != null) Debug.LogError("Only 1 WordSpawner allowed to exist");
        WordSpawner.instance = this;
    }
}
