using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalFunctions : MonoBehaviour
{
    public static GlobalFunctions Instance { get; private set; }
    public bool useVH;
    private TextMeshProUGUI DebugText;
    private GameObject LeftHand;
    private GameObject RightHand;
    private GameObject [] trackedHands;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DebugText = GameObject.Find("DebugText").GetComponentInChildren<TextMeshProUGUI>();
        LeftHand = GameObject.Find("LeftHand");
        RightHand = GameObject.Find("RightHand");
        trackedHands = new GameObject [] {GameObject.Find("LeftOVRHand"), GameObject.Find("RightOVRHand")};
    }

    public void WriteDebugText(string s){
        DebugText.text = s;
    }

    public GameObject getHandVisuals(string s)
    {
        if(s.ToLower().Equals("left")){
            return LeftHand;
        }
        return RightHand;

    }

    public GameObject[] getOVRHands(){
        return trackedHands;
    }

    public bool areVHsInUse(){
        return useVH;
    }
}
