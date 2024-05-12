/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private RectTransform sanityBar;

    [SerializeField]
    private float sanity;

    [SerializeField]
    private float maxSanity = 100f;
    
    void Start()
    {
        sanity = maxSanity;
    }

    // Update is called once per frame
    void Update()
    {
        if(sanity > 0.1f)
        {
            //testing if sanity goes down with rectTransform
            //sanity = sanity - 0.1f;
            UpdateSanityBar();
            PlayerMovement playerMovementSwap = player.GetComponent<PlayerMovement>();
            playerMovementSwap.SetSanity(true);
        }
        if(sanity < 51f)
        {
            PlayerMovement playerMovementSwap = player.GetComponent<PlayerMovement>();
            playerMovementSwap.SetSanity(false);
        }   
    }

    public void UpdateSanityBar()
    {
        float currentScale = sanity / 100f;
        
        sanityBar.localScale = new Vector3(1f,currentScale,1f);
    }

    public void DecreaseSanity(float sanityAmount)
    {
        sanity = sanity - sanityAmount;
        if(sanity <= 0)
        {
            sanity = 0.2f;
            // aqui colocar o random debuff?
        }
    }
}
 */