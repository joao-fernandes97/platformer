using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityManager : MonoBehaviour
{
    public static SanityManager Instance {get; private set;}
    public float sanityInstance = 100f;
    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);
        else
            Instance = this;
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
    }
}
