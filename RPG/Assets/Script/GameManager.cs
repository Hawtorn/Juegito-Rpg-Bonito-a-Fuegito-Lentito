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

    public int gold;

    public GameObject battlePlayerPrefab;
    public GameObject battleEnemyPrefab;

    public List<string> skills;

    public List<Equipment> equipamentOnSale;

    public List<Equipment> equipamentBought;
    public Equipment weapon;
    public Equipment armor;
    public Equipment accesory;

    void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        skills = new List<string>();
        skills.Add("Attack");
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void PreloadManagers()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Managers", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
