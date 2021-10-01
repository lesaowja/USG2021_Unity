using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutPizzaScript : MonoBehaviour
{ 
    [SerializeField] RayMng raymng;

    [SerializeField] GameObject FinPizza;
    // Start is called before the first frame update
    void Start()
    { 
        raymng = GameObject.Find("Player").GetComponent<RayMng>();
    }
   
    private void OnTriggerStay(Collider nap)
    {
        if (nap.tag == "Selectable")
        {
            Debug.Log("PizzaCOme");
            if(raymng.HaveCutter)
            {
                if (Input.GetKeyUp(KeyCode.G))
                {
                    Debug.Log("Test");
                    Transform PizzaPosition = nap.gameObject.transform;
                    Destroy(nap.gameObject);
                    Instantiate(FinPizza, new Vector3(PizzaPosition.position.x, PizzaPosition.position.y, PizzaPosition.position.z), Quaternion.identity);

                }
            }
            

        }

        

    }
}
