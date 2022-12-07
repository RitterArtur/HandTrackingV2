using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyContainerSubTask : MonoBehaviour
{
    private int numberOfItems;
    private int numberOfEmptiedItems;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        numberOfItems = this.transform.childCount;

    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEmptiedItems > numberOfItems * 0.7)
        {
            if (!done)
            {
                SoundManager.instance.Play("Ding");
                done = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.transform.parent.parent.parent.name.Contains("Left") && !other.gameObject.transform.parent.parent.parent.name.Contains("Right"))
        {

            numberOfEmptiedItems++;

        }

    }

    public bool tastkStatus(){
        return done;
    }
}
