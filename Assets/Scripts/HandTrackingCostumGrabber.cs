using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackingCostumGrabber : OVRGrabber
{
    private OVRHand hand;
    private float pinchThreshold = 0.7f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        CheckPinch();
    }

    void CheckPinch(){
        float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        bool isPinching = pinchStrength > pinchThreshold;

        if(!m_grabbedObj && isPinching && m_grabCandidates.Count>0){
            GrabBegin();
        }else if(m_grabbedObj && !isPinching){
            GrabEnd();
        }
    }
}
