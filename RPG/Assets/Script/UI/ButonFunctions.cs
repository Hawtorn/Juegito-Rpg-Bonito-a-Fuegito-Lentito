using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonFunctions : MonoBehaviour
{
    public void StarBattle(GameObject enemyPrefab)
    {
        GameManager.Instance.battleEnemyPrefab = enemyPrefab;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }
}
