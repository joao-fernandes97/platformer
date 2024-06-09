using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class PPCtrl : MonoBehaviour
{
    [SerializeField]
    TilemapRenderer         eldritchWorld;
    Volume                  volume;
    FilmGrain               fg; 

    
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out fg);
    }

    // Update is called once per frame
    void Update()
    {
        fg.active = eldritchWorld.enabled;
    }
}
