using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixYRotation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));


    }
}
