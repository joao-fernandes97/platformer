using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    [SerializeField]
    private GameObject          player;
    [SerializeField]
    private TilemapRenderer     eldritchMap;
    [SerializeField]
    private Image               circleUIBar;
    [SerializeField]
    private float               sanity;
    [SerializeField]
    private float               maxSanity = 100f;

    private float               breakdownChance = 50f;
    private bool                sanityReducedOnce = false; 
    private bool                protectionHit = false;
    private bool                enableEldritchWorld = false;

    private List<int>           debuffs = new List<int>();
    
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
        UpdateSanityBar();
        if(sanity <=0f)
        {
            ResolveTest();
        }
       
        enableEldritchWorld = eldritchMap.enabled;
        
        EldritchWorld(enableEldritchWorld,0.02f);
    }

    public void UpdateSanityBar()
    {
        //float currentScale = sanity / 100f;
        float currentFillAmount = ScaleValue(sanity, 0f, 100f, 0.3f, 1f);
        
        //sanityBar.localScale = new Vector3(1f,currentScale,1f);
        circleUIBar.fillAmount = currentFillAmount;
    }

    private float ScaleValue(float originalValue, float minV, float maxV, float minT, float maxT)
    {
        float proportion = (originalValue-minV)/(maxV-minV);

        return proportion * (maxT-minT) + minT;
    }
    
    public void CrawlerGrab(float amount)
    {
        if(!protectionHit)
        {
            sanity -= amount; //10
        
        }
        else
        {
            protectionHit = false;
        }
    }

    public void EldritchWorld(bool open, float amount)
    {
        if(open)
        {
            if(!sanityReducedOnce)
            {
                sanity -= 5;
                sanityReducedOnce = true;
            }
            sanity -= amount; //1
        }
        else
        {
            sanityReducedOnce = false;
        }
    }

    public void WrongPuzzleChoice(float amount)
    {
        sanity -= amount; // 10?
        
    }

    public void PuzzleHint(float amount)
    {
        sanity -= amount; // 20?
        
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
            BreakDown(50);
            breakdownChance = breakdownChance + 20f;
            int randomIndex = Random.Range(0, debuffs.Count);
            int randomOption = debuffs[randomIndex];
            if(randomOption == 1)
                Paranoia();
            if(randomOption == 2)
                Panic();
            if(randomOption == 3)
                BrokenWill();
            // player can have same debuffs or we just Pop() the option?

        }
        else
        {
            Breakthrough(75);
            breakdownChance = breakdownChance + 10f;
            EpiphanyState();
        }

        if(breakdownChance >= 100f)
        {
            PlayerMovement playerDeath = player.GetComponent<PlayerMovement>();
            playerDeath.PlayerDied();
            
            
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOverMenu();
            }
        }
    }

    public void Paranoia()
    {
        //The light circle around the character becomes a cone pointed ahead
        Debug.Log("Lights changed");
    }

    public void Panic()
    {
        StartCoroutine(PanicCR());
    }

    private IEnumerator PanicCR()
    {
        //after enemy attack, SetSanity is false for 5 secs.
        //to do this maybe a changing a bool to true at randomOption == 2
        //Animation fog or GUI
        Debug.Log("swap movement");
        yield return new WaitForSeconds(2);
        PlayerMovement playerMovementSwap = player.GetComponent<PlayerMovement>();
        playerMovementSwap.SetSanity(false);

        yield return new WaitForSeconds(5);
        playerMovementSwap.SetSanity(true);
        //End of animation fog or GUI
    }

    public void BrokenWill()
    {
        Debug.Log("movement speed slow");
        PlayerMovement playerMovementSpeed = player.GetComponent<PlayerMovement>();
        playerMovementSpeed.SetSpeed(); // reduce mov.speed 50%
    }

    public void EpiphanyState()
    {
        Debug.Log("1 hit protection");
        protectionHit = true;
        // hint puzzle no cost of sanity
    }

    public void ResetSanity()
    {
        sanity = 100f;
        breakdownChance = 50f;
        PlayerMovement playerMovementSpeed = player.GetComponent<PlayerMovement>();
        playerMovementSpeed.ResetMVSpeed(); 
        //light
        //Animation
    }
}
