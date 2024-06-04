using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator        animator;
    private PlayerMovement  movement;
    [SerializeField]
    private GameController  gameController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(name);
        Debug.Log(collider.gameObject.tag);
        //Debug.Log(collider.gameObject.name);
        if(collider.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("PlayerCaught");
        }
    }

    //Triggered by animation event on player
    public void CaughtAnimStart()
    {
        gameController.SetCanSwitch(false);
        movement.DisableMovement();
    }

    //Triggered by Animation Event on Player
    public void CaughtAnimEnd()
    {
        Debug.Log("Switch");
        gameController.ToggleEnvironment();
        movement.EnableMovement();
        StartCoroutine(SwitchCooldown(5));

    }

    private IEnumerator SwitchCooldown(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        EnableSwitching();
    }
    
    public void EnableSwitching()
    {
        gameController.SetCanSwitch(true);
    }

    

}
