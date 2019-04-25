using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFXManager : MonoBehaviour
{
 public static GFXManager Instance { get; private set; }

    public GameObject[] gfxPrefabs;

    void Awake()
    {
        Instance = this;
    }
}
