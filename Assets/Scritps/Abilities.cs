using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public static bool isShield;
    public static bool isMagnit;
    public RawImage shields;
    public RawImage magnit;
    void Start()
    {
        isShield = false;
        isMagnit = false;
    }

    private void Update()
    {
        if (isShield == true)
        {
            shields.color = Color.green;
        }
        else
        {
            shields.color = Color.white;
        }

        if (isMagnit == true)
        {
            magnit.color = Color.green;
        }
        else
        {
            magnit.color = Color.white;
        }
    }

    public void ActivateShield()
    {
        if (Shop.shieldcount > 0)
        {
        isShield = true;
        Shop.shieldcount--;
        }

        
    }

    public void ActivateMagnit()
    {
        if (Shop.magnitcount > 0)
        {
            isMagnit = true;
            Invoke(nameof(EndMagnit), 4f);
            Shop.magnitcount--;
        }
    }

    private void EndMagnit()
    {
        isMagnit = false;
    }
}
