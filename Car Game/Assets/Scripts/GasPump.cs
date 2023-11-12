using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPump : MonoBehaviour
{
    [SerializeField] float pricePerGallon = 5.0f;

    public void BuyGas(Player player)
    {
        float money = player.GetMoney();
        float gas = player.GetGas();
        float gasMax = player.GetGasMax();
        float gasNeeded = gasMax - gas;

        if(gasNeeded * pricePerGallon <= money)
        {
            Debug.Log("here1");
            player.SubtractMoney(gasNeeded * pricePerGallon);
            player.FillGas(gasNeeded);
        }
        else
        {
            Debug.Log("here2");
            player.SubtractMoney(money);
            player.FillGas(money / pricePerGallon);
        }
    }
}
