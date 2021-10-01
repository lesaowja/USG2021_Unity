using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    PixelController Name;
    public string n1;
    public Text NameLabel;
    public Text MoneyLabel;

    public int HaveMoney = 0;
    public TextMeshPro Mymesh;
    private void Start()
    {
        Name = GameObject.Find("Controller").GetComponent<PixelController>();
        n1 = Name.user;
        NameLabel.text = n1;
        Mymesh.text = n1;
    }
    // Update is called once per frame
    public void SetMoney()
    {
        string Money = HaveMoney.ToString();
        MoneyLabel.text = Money;
    }
}
