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
    Vignette                vt;
    ColorAdjustments        ca;
    Sanity                  sanity;
    

    
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out fg);
        volume.profile.TryGet(out vt);
        volume.profile.TryGet(out ca);
        sanity = FindObjectOfType<Sanity>();
    }

    // Update is called once per frame
    void Update()
    {
        fg.active = eldritchWorld.enabled;
        ca.active = eldritchWorld.enabled;
        vt.intensity = new ClampedFloatParameter(ScaleValue(sanity.BreakdownChance, 50f, 100f, 0.3f, 0.8f), 0f, 1f);
    }

    private float ScaleValue(float originalValue, float minV, float maxV, float minT, float maxT)
    {
        float proportion = (originalValue-minV)/(maxV-minV);

        return proportion * (maxT-minT) + minT;
    }
}
