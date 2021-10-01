using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPizza : MonoBehaviour
{
    GameController Gcontroller;
    private void Start()
    {
        Gcontroller = GameObject.Find("GameController").GetComponent<GameController>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Selectable")
        {
            Destroy(other.gameObject);
            Gcontroller.HaveMoney += 4000;
            Gcontroller.SetMoney();
        }
    }
}
