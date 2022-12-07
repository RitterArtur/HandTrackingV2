using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class abstractLevelController : MonoBehaviour
{
    public Tasks[] taskOrder;
    protected int currentTaskNumber = 0;


    // Update is called once per frame
    protected virtual void Update()
    {
        if (taskOrder.Length <= currentTaskNumber)
            return;

        if (taskOrder[currentTaskNumber].call())
        {
            handleSequence();
            currentTaskNumber++;
            if(taskOrder.Length>currentTaskNumber)
                taskOrder[currentTaskNumber].init();
        }
    }

    protected abstract void handleSequence();
}
