using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HUDEffects : MonoBehaviour
{
    public GameObject itemParent;
    public float triggerDistance;
    protected bool inArea;
    protected GameObject lHand;
    protected GameObject rHand;
    protected List<GameObject> children;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract bool isDone();
}
