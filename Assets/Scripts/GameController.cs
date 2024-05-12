using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject real;
    [SerializeField]
    private GameObject eldritch;
    private TogEnvironment realToggle;
    private TogEnvironment eldritchToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        realToggle = real.GetComponent<TogEnvironment>();
        eldritchToggle = eldritch.GetComponent<TogEnvironment>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !realToggle.IsInsideGeometry && !eldritchToggle.IsInsideGeometry) 
        {
            realToggle.ToggleEnvironment();
            eldritchToggle.ToggleEnvironment();
        }


    }
}
