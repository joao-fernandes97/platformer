/*using System.Collections;
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

    private float breakdownChance = 50f;

    private bool sanityReducedOnce = false;

    private List<int> debuffs = new List<int>();
    
    void Start()
    {
        sanity = maxSanity;
        debuffs.Add(1);
        debuffs.Add(2);
        debuffs.Add(3);
    }

    // Update is called once per frame
    void Update()
    {
        if(sanity > 0.1f)
        {
            //testing if sanity goes down with rectTransform
            //sanity = sanity - 0.1f;
            UpdateSanityBar();
            //PlayerMovement playerMovementSwap = player.GetComponent<PlayerMovement>();
            //playerMovementSwap.SetSanity(true);
        }  
    }

    public void UpdateSanityBar()
    {
        float currentScale = sanity / 100f;
        
        sanityBar.localScale = new Vector3(1f,currentScale,1f);
    }

    public void CrawlerGrab(float amount)
    {
        sanity = sanity - amount; //10
        if(sanity <= 0f)
        {
            sanity = 0.2f;
        }
    }

    public void EldritchWorld(bool open, float amount)
    {
        if(open)
        {
            if(!sanityReducedOnce)
            {
                sanity = sanity - 5;
                sanityReducedOnce = true;
            }
            sanity = sanity - amount; //1
            
            if(sanity <= 0f)
            {
                sanity = 0.2f;
            }
        }
        else
        {
            sanityReducedOnce = false;
        }
    }

    public void WrongPuzzleChoice(float amount)
    {
        sanity = sanity - amount; // 10?
        if(sanity <= 0f)
        {
            sanity = 0.2f;
        }
    }

    public void PuzzleHint(float amount)
    {
        sanity = sanity - amount; // 20?
        if(sanity <= 0f)
        {
            sanity = 0.2f;
        }
    }

    public void Breakthrough(float amount)
    {
        sanity = amount; //+ 75 or to +25 (-50/0/50)
    }

    public void BreakDown(float amount)
    {
        sanity = amount; // +50 or to 0 (-50/0/50)
    }

    public void RestingBed(float amount)
    {
        if(sanity <= 60f)
        {
            sanity = amount; //60 or +10 (-50-0-50)
        }
    }

    public void ResolveTest()
    {
        float randomChance = Random.Range(0f, 100);

        if(randomChance <= breakdownChance)
        {
            breakdownChance = breakdownChance + 20f;
            int randomIndex = Random.Range(0, debuffs.Count);
            int randomOption = debuffs[randomIndex];
            if(randomOption == 1)
                Paranoia();
            if(randomOption == 2)
                Panic();
            if(randomOption == 3)
                BrokenWill();

        }
        else
        {
            breakdownChance = breakdownChance + 10f;
            // protect against enemy attack or trade for puzzle hint with no sanity cost
            EpiphanyState();
        }

        if(breakdownChance >= 100f)
        {
            PlayerMovement playerDeath = player.GetComponent<PlayerMovement>();
            playerDeath.PlayerDied();
        }
    }

    public void Paranoia()
    {
        //The light circle around the character becomes a cone pointed ahead
    }

    public void Panic()
    {
        //after enemy attack, SetSanity is false for 5 secs.
        //Animation fog or GUI
        //Coroutine 5 secs
        PlayerMovement playerMovementSwap = player.GetComponent<PlayerMovement>();
        playerMovementSwap.SetSanity(false);

        //after 5 secs
        //playerMovementSwap.SetSanity(true);
    }

    public void BrokenWill()
    {
        PlayerMovement playerMovementSpeed = player.GetComponent<PlayerMovement>();
        playerMovementSpeed.SetSpeed(); // reduce mov.speed 50%
    }

    public void EpiphanyState()
    {
        //protection variable true;
        // hint puzzle no cost of sanity
    }
}*/
