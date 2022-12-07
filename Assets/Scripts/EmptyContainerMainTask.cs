using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyContainerMainTask : Tasks
{
    private EmptyContainerSubTask[] subTasks;
    
    public override bool call()
    {
        int completedSubTasks =0;
        for(int i=0;i<subTasks.Length;i++){
            if(subTasks[i].tastkStatus()){
                completedSubTasks++;
            }
        }
        GlobalFunctions.Instance.WriteDebugText(completedSubTasks + " completed");
        if(completedSubTasks == subTasks.Length){
           return true;
        }
        return false;
    }

    public override void init()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
       subTasks=  GetComponentsInChildren<EmptyContainerSubTask>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
