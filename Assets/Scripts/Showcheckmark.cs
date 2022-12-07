using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Showcheckmark : MonoBehaviour
{
    public EmptyContainerSubTask task;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(task.done)
            GetComponent<Image>().enabled = true;
    }
}
