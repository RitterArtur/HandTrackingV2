using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.GrabAPI;
using Oculus.Interaction.HandPosing;

public class LiftObjectOffset : MonoBehaviour
{
    [Range(0, 0.8f)]public float weight;
    private GameObject leftHandVisual;
    private GameObject rightHandVisual;
    private GameObject leftOVRHand;
    private GameObject rightOVRHand;
    private HandGrabInteractor rightInteractor;
    private HandGrabInteractor leftInteractor;
    private HandGrabAPI leftGrabAPI;
    private HandGrabAPI rightGrabAPI;
    private GameObject grabbedObject;
    private Vector3 startPos;
    private Vector3 lastPos;
    private bool grabbedWithRightHand;
    private bool grabbedWithLeftHand;
    private bool active;
    private float yOffset;
    private bool inUse;



    // Start is called before the first frame update
    void Start()
    {
        leftHandVisual = GameObject.Find("OculusHand_L");
        rightHandVisual = GameObject.Find("OculusHand_R");
        rightInteractor = GameObject.Find("HandGrabInteractorRight").GetComponent<HandGrabInteractor>();
        leftInteractor = GameObject.Find("HandGrabInteractorLeft").GetComponent<HandGrabInteractor>();
        leftGrabAPI = GameObject.Find("HandGrabInteractorLeft").transform.GetChild(1).GetComponent<HandGrabAPI>();
        rightGrabAPI = GameObject.Find("HandGrabInteractorRight").transform.GetChild(1).GetComponent<HandGrabAPI>();
        leftOVRHand = GameObject.Find("LeftExtraAnchor");
        rightOVRHand = GameObject.Find("RightOVRHand");
        inUse = GlobalFunctions.Instance.areVHsInUse();

    }

    // Update is called once per frame
    void Update()
    {
        checkForGrab();
        
        if(inUse)
            offsetHand();

        transform.rotation = Quaternion.Euler(0f,90f,0f);
       
    }

    void checkForGrab()
    {

        if (rightInteractor.HasSelectedInteractable || leftInteractor.HasSelectedInteractable)
        {
            if (getGrabbedObjectRoot())
            {
                active = true;
                return;
            }
        }
        grabbedWithRightHand = false;
        grabbedWithLeftHand = false;
        return;



    }

    bool getGrabbedObjectRoot()
    {

        if (rightInteractor.HasSelectedInteractable)
        {

            //will check interactable for parent and search meshes from there. Needed if Interactables are structered like in OVR Framework
            if (rightInteractor.Interactable.gameObject.transform.parent.gameObject != null)
            {
                grabbedObject = rightInteractor.Interactable.gameObject.transform.parent.gameObject;

            }
            else
            {
                grabbedObject = rightInteractor.Interactable.gameObject;
            }

            if (!grabbedWithRightHand)
                startPos = rightOVRHand.transform.position;

            if (gameObject.name.Equals(grabbedObject.name))
                grabbedWithRightHand = true;

            return true;

        }
        else if (leftInteractor.HasSelectedInteractable)
        {
            //will check interactable for parent and search meshes from there. Needed if Interactables are structered like in OVR Framework
            if (leftInteractor.Interactable.gameObject.transform.parent.gameObject != null)
            {
                grabbedObject = leftInteractor.Interactable.gameObject.transform.parent.gameObject;
            }
            else
            {
                grabbedObject = leftInteractor.Interactable.gameObject;
            }

            if (!grabbedWithLeftHand)
                startPos = leftOVRHand.transform.position;

            if (gameObject.name.Equals(grabbedObject.name))
                grabbedWithLeftHand = true;


            return true;

        }

        return false;
    }

    void offsetHand()
    {

        if (grabbedWithRightHand)
        {

            //Calculation
            Transform actualPosition = rightOVRHand.transform.GetChild(0).transform;
            Vector3 tempT = actualPosition.position - startPos;

            if(rightOVRHand.GetComponent<OVRHand>().IsDataHighConfidence){
                lastPos =new Vector3(actualPosition.position.x,actualPosition.position.y - (tempT.y * weight) , actualPosition.position.z);
            }

            GlobalFunctions.Instance.WriteDebugText(lastPos.ToString());
            //Apply to Hand Model
            rightHandVisual.transform.position = lastPos ;
            //rightInteractor.transform.parent.position = new Vector3(actualPosition.position.x,actualPosition.position.y - (tempT.y * 0.5f) , actualPosition.position.z) ;

            //Apply to Virtual Hand Position and apply wrist offset
            rightInteractor.transform.GetChild(2).transform.position = lastPos ;
            rightInteractor.transform.GetChild(2).transform.localPosition += new Vector3(0.0f,-0.03f,0.11f);

            return;

        }

        if (grabbedWithLeftHand)
        {
            //Calculation
            Transform actualPosition = leftOVRHand.transform.GetChild(0).transform;
            Vector3 tempT = actualPosition.position - startPos;

            if(rightOVRHand.GetComponent<OVRHand>().IsDataHighConfidence){
                lastPos =new Vector3(actualPosition.position.x,actualPosition.position.y - (tempT.y * weight) , actualPosition.position.z);
            }

            //Apply to Hand Model
            leftHandVisual.transform.position = lastPos;
            //rightInteractor.transform.parent.position = new Vector3(actualPosition.position.x,actualPosition.position.y - (tempT.y * 0.5f) , actualPosition.position.z) ;

            //Apply to Virtual Hand Position and apply wrist offset
            leftInteractor.transform.GetChild(2).transform.position =lastPos ;
            leftInteractor.transform.GetChild(2).transform.localPosition += new Vector3(-0.0f,-0.03f,0.11f);

            return;
        }

        if(!grabbedWithLeftHand && active)
        {
            active = false;
           // leftHandVisual.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        }
        if(!grabbedWithRightHand && active)
        {
            active = false;
            //rightHandVisual.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        }

    }
}
