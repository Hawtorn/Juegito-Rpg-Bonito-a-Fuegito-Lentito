using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public CharacterStats playerCharactersStats;
    public int playerExperience;
    public int gainedExperience;
    public int upgradePoints;

    public GameObject battlePlayerPrefab;
    public GameObject battleEnemyPrefab;

    void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void PreloadManagers()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Managers", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
