using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction.GrabAPI;
using Oculus.Interaction;
using Oculus.Interaction.HandPosing;

public class HandPoseChecker : MonoBehaviour
{

    private OVRHand hand;
    private HandGrabAPI grabAPI;
    private HandGrabInteractor handGrabInteractor;
    private GameObject grabbedObject;
    private Color StartHandColor;
    private Level2Controller level2Controller;
    public Material handMaterial;
    public HandGrabInteractor grabInteractor;
    public GameObject particles;
    private bool freshGrab;
    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
        grabAPI = grabInteractor.GetComponentInChildren<HandGrabAPI>();
        handGrabInteractor = grabInteractor.GetComponent<HandGrabInteractor>();
        StartHandColor = handMaterial.GetColor("_ColorTop");
        level2Controller = GameObject.Find("SCRIPTS").GetComponent<Level2Controller>();
    }

    // Update is called once per frame
    void Update()
    {


        if( (grabAPI.IsHandPalmGrabbing(GrabbingRule.DefaultPalmRule)||grabAPI.IsHandPinchGrabbing(GrabbingRule.DefaultPinchRule) ) 
            && handGrabInteractor.HasSelectedInteractable){

            if (!GlobalFunctions.Instance.areVHsInUse())
                return;
            handMaterial.SetFloat("_FresnelPower", 0.2f );

            //will check interactable for parent and search meshes from there. Needed if Interactables are structered like in OVR Framework
           if(handGrabInteractor.Interactable.gameObject.transform.parent.gameObject != null){
               grabbedObject = handGrabInteractor.Interactable.gameObject.transform.parent.gameObject;
           }else{
               grabbedObject = handGrabInteractor.Interactable.gameObject;
           }
           if(!freshGrab){
                freshGrab = true;
                 level2Controller.onGrabLevelEvent(this.gameObject,grabbedObject);
           }

           if(grabbedObject.GetComponentInChildren<MeshRenderer>() != null){
               //handMaterial.SetColor("_ColorTop", grabbedObject.GetComponentInChildren<MeshRenderer>().material.color );

                //particles.GetComponent<AttachToTarget>().newGrabpoint(handGrabInteractor.gameObject);
                //particles.SetActive(true);
               //particles.transform.position = grabbedObject.transform.position;

               if(particles.GetComponent<ParticleSystem>().isPaused || particles.GetComponent<ParticleSystem>().isStopped){
                   // particles.GetComponent<ParticleSystem>().Play();
               }
           }


        }else{
            if(freshGrab){
                level2Controller.onDropEvent(this.gameObject);
                freshGrab = false;
            }
            handMaterial.SetFloat("_FresnelPower",1.75f );
           // GameObject.Find("HotParticles").GetComponent<ParticleSystem>().Stop();
            //handMaterial.SetColor("_ColorTop",StartHandColor );
        }


        /*Delete Later -  might be usefull
                float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle);
        if(hand.GetFingerConfidence(OVRHand.HandFinger.Index) == OVRHand.TrackingConfidence.High)
            //handMaterial.SetFloat("_FresnelPower",0.16f + (pinchStrength*3) );
        //text.text = grabAPI.GetHandPinchStrength(GrabbingRule.DefaultPalmRule).ToString();
        //text.text = grabAPI.GetHandPalmStrength(GrabbingRule.DefaultPinchRule).ToString();
        //handMaterial.SetFloat("_FresnelPower",0.16f + (grabAPI.GetHandPalmStrength(GrabbingRule.FullGrab)  *3.0f) );

        */

    }

    
}
