using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenFunction : MonoBehaviour
{
    [SerializeField]OvenMove oven;
    [SerializeField] RayMng raymng;
    public bool HavePizza = false;
    [SerializeField]GameObject FirstPizza;
    [SerializeField] GameObject SecondPizza;
    [SerializeField]Transform PizzaPlace;
    // Start is called before the first frame update
    void Start()
    {
        oven = GameObject.Find("Pizza Oven Door 03").GetComponent<OvenMove>();
        raymng = GameObject.Find("Player").GetComponent<RayMng>();
    }

    private void OnTriggerEnter(Collider nap)
    {
        if (nap.tag == "Selectable")
        {
            HavePizza = true;
        }
    }
    private void OnTriggerExit(Collider nap)
    { 
    }
    private void OnTriggerStay(Collider nap)
    {
        if (nap.tag == "Player")
        {
            if (raymng.HaveObject)
            {
                if (oven.open)
                {
                    if (Input.GetKeyDown(KeyCode.G))
                    { 
                        raymng.DestroyChild();
                        Instantiate(FirstPizza, new Vector3(PizzaPlace.position.x, PizzaPlace.position.y, PizzaPlace.position.z), Quaternion.identity);

                    }

                }

            }

        }

        if (nap.tag == "Selectable")
        {
            if (HavePizza)
            {
                if (!oven.open)
                {
                    Destroy(nap.gameObject);
                    Instantiate(SecondPizza, new Vector3(PizzaPlace.position.x, PizzaPlace.position.y, PizzaPlace.position.z), Quaternion.identity);

                }
            }
        }

    }
}
