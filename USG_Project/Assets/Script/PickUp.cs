using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //public Transform Dest;
    public void MouseDown()
    {
        //GetComponent<Rigidbody>().useGravity = false;
        //this.transform.position = Dest.position;
        //this.transform.parent = GameObject.Find("Destination").transform;
    }
    public void MouseUp()
    {
        //this.transform.parent = null;
        //GetComponent<Rigidbody>().useGravity = true;

    }
}
