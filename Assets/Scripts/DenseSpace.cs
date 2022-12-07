using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenseSpace : MonoBehaviour
{
    public float Density;

    // Transforms and Vectors to calculate Offset and move Hand accordingly
    private Transform actualPosition;
    private Vector3 offset;
    private Transform currentHandTransform;
    private Vector3 insertionPoint;

    //  Hand meshes wich are moved
    private GameObject leftHandVisual;
    private GameObject rightHandVisual;
    private GameObject leftOVRHand;
    private GameObject rightOVRHand;
    private GameObject rightInteractors;
    private GameObject leftInteractors;
    Oculus.Interaction.HandWristOffset leftGripPoint;
    Oculus.Interaction.HandWristOffset rightGripPoint;
    private Vector3 GripPointOffset;

    private bool active;
    private bool inUse;
    private bool leftIsActive;
    private bool rightIsActive;
    private int inTrigger;

    int num;
    // Start is called before the first frame update
    void Start()
    {
        leftHandVisual = GameObject.Find("OculusHand_L");
        rightHandVisual = GameObject.Find("OculusHand_R");
       // leftHandVisual = GameObject.Find("HandInteractorsLeft");
        rightInteractors = GameObject.Find("HandGrabInteractorRight").transform.GetChild(2).gameObject;
        leftInteractors = GameObject.Find("HandGrabInteractorLeft").transform.GetChild(2).gameObject;
        leftOVRHand = GameObject.Find("LeftExtraAnchor");
        rightOVRHand = GameObject.Find("RightExtraAnchor");
        rightGripPoint = rightInteractors.GetComponent<Oculus.Interaction.HandWristOffset>();
        leftGripPoint = leftInteractors.GetComponent<Oculus.Interaction.HandWristOffset>();
        GripPointOffset = rightGripPoint.Offset;
        inUse = GlobalFunctions.Instance.areVHsInUse();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            //GlobalFunctions.Instance.WriteDebugText("Hello");
            //leftHandVisual.transform.position = leftOVRHand.transform.position;
            //rightHandVisual.transform.position = rightOVRHand.transform.position;

            //HandPositionUpdate();
        }

        if (inTrigger < 10)
                inTrigger++;

    }

    void Update()
    {
        if(!inUse)
            return;
        //  GlobalFunctions.Instance.WriteDebugText(active.ToString() + " " + inTrigger.ToString());
        if (active)
        {
            HandPositionUpdate();
            if (inTrigger > 5)
            {
                num++;
                active = false;

                if (leftIsActive)
                {
                    leftOVRHand.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    leftHandVisual.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                    leftGripPoint.Offset = GripPointOffset;
                }
                if (rightIsActive)
                {
                    rightOVRHand.transform.localPosition =  new Vector3(0.0f, 0.0f, 0.0f);
                    rightHandVisual.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                    rightGripPoint.Offset = GripPointOffset;
                    
                    //rightInteractors.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                }

                rightIsActive = false;
                leftIsActive = false;

                //GlobalFunctions.Instance.WriteDebugText("MATSUMOTO OUTO");
            }

            


        }

        //GlobalFunctions.Instance.WriteDebugText(active.ToString() + " " + inTrigger.ToString());
    }

    bool checkCapsules()
    {
        if (GetComponent<CapsuleCollider>().bounds.Intersects(leftHandVisual.transform.parent.GetComponent<CapsuleCollider>().bounds) ||
            GetComponent<CapsuleCollider>().bounds.Intersects(rightHandVisual.transform.parent.GetComponent<CapsuleCollider>().bounds))
        {
            return true;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (checkForCollider(other))
        {

            if (other.gameObject.transform.parent.parent.parent.name.Contains("Left"))
            {
                leftIsActive = true;
            }
            else if (other.gameObject.transform.parent.parent.parent.name.Contains("Right"))
            {
                rightIsActive = true;
            }


            if (active == true)
            {
                return;
            }
            active = true;
            currentHandTransform = other.gameObject.transform.parent.parent.parent.parent;
            actualPosition = currentHandTransform.parent;
            currentHandTransform.position = actualPosition.position;
            insertionPoint = actualPosition.position;
            return;
        }

    }
    void OnTriggerStay(Collider other)
    {
        //GlobalFunctions.Instance.WriteDebugText("Collision: " + other.name);
        if (checkForCollider(other))
        {
            //GlobalFunctions.Instance.WriteDebugText("Collision: " + other.name);
            inTrigger = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {


        // if (checkForCollider(other))
        if (false)
        {
            active = false;
            rightIsActive = false;
            leftIsActive = false;
        }
        //if(other.gameObject.tag == "HandCollision")
        //  GlobalFunctions.Instance.WriteDebugText("Out");

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "HandCollision")
            GlobalFunctions.Instance.WriteDebugText("Collision");

    }

    void HandPositionUpdate()
    {
        offset = actualPosition.position - insertionPoint;

        if (leftIsActive)
        {
            leftHandVisual.transform.position = actualPosition.position - (offset * Density);
            leftOVRHand.transform.position = actualPosition.position - (offset * Density);

            leftGripPoint.transform.position = actualPosition.position - (offset * Density) ;
            leftGripPoint.transform.localPosition += new Vector3(0.0f,-0.03f,0.11f);
        }
        else if (rightIsActive)
        {
            rightHandVisual.transform.position = actualPosition.position - (offset * Density);
            rightOVRHand.transform.position = actualPosition.position - (offset * Density);
           // rightInteractors.transform.position = actualPosition.position - (offset * Density);
            //GripPoint.Offset = GripPointOffset - (offset * Density);
            rightGripPoint.transform.position = actualPosition.position - (offset * Density) ;
            rightGripPoint.transform.localPosition += new Vector3(0.0f,-0.03f,0.11f);
        }
        //GameObject.Find("OculusHand_L").transform.position +=  new Vector3(0.0f,0.1f,0.0f);
        // GlobalFunctions.Instance.WriteDebugText("Im in");
    }

    bool checkForCollider(Collider coll)
    {
        //GlobalFunctions.Instance.WriteDebugText("Collision: " + coll.gameObject.transform.parent.name);
        if (coll.gameObject.name.Contains("Capsule"))
        {
            //GlobalFunctions.Instance.WriteDebugText("collider: " + coll.gameObject.transform.parent.parent.parent.name);
            //if(coll.gameObject.name.Contains("l_"))
            return true;


        }

        return false;
    }
}
