using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.HandPosing;
using UnityEngine;

public class hotKeyScript : Tasks
{

    private HandGrabInteractor rightInteractor;
    private HandGrabInteractor leftInteractor;
    private bool grabbedWithRightHand;
    private bool grabbedWithLeftHand;
    public GameObject smoke;

    // Start is called before the first frame update
    void Start()
    {
        rightInteractor = GameObject.Find("HandGrabInteractorRight").GetComponent<HandGrabInteractor>();
        leftInteractor = GameObject.Find("HandGrabInteractorLeft").GetComponent<HandGrabInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        checkForGrab();
    }

    void checkForGrab()
    {

        if (rightInteractor.HasSelectedInteractable || leftInteractor.HasSelectedInteractable)
        {
           
        }
        smoke.SetActive( false);
        grabbedWithRightHand = false;
        grabbedWithLeftHand = false;
        return;
    }

    
    public override bool call(){
        checkForGrab();
        return false;
    }

    public override void init()
    {
        
    }
}
