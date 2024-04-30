using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public static float balance = 0;
    public TMP_Text balancetext;
    public static float magnitcount = 0;
    public static float shieldcount = 0;
    private static float currentprice;
    private static float currentbalance;
    private void Update()
    {
        balancetext.text = balance.ToString();
    }
    public static void Payment(float price)
    {
        currentprice = price;
        currentbalance = balance;

        if (currentprice <= balance)
        {
            balance = balance - price;
        }

    }
    public void TypeOfPay(string ability)
    {
        if (currentprice <= currentbalance)
        {
            Invoke(ability, 0);
        }
        Debug.Log(shieldcount);
    }

    public float Magnit()
    {
        return magnitcount++;
    }
    public float Shield()
    {
        return shieldcount++;
    }
    public static float RemoveMagnit()
    {
        return magnitcount--;
    }
    public static float RemoveShield()
    {
        return shieldcount--;
    }


}

    


 

 
