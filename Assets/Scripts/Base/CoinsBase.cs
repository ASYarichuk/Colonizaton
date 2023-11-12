using System.Collections.Generic;
using UnityEngine;

public class CoinsBase : MonoBehaviour
{
    [SerializeField] private List<Coin> _coins = new ();

    [SerializeField] private int _availableMoney = 0;

    private int _amountCoins = 0;

    public void Add(Coin coin)
    {
        _coins.Add(coin);
    }

    public void Delete(Coin coin)
    {
        _coins.Remove(coin);
    }

    public int ShowAmount()
    {
        _amountCoins = _coins.Count;

        return _amountCoins;
    }

    public Coin TakeFirstCoin()
    {
        if(_coins.Count > 0)
        {
            return _coins[0];
        }
        else
        {
            return null;
        }
    }

    public void AddAvailableMoney(int amountBroughtMoney)
    {
        _availableMoney += amountBroughtMoney;
    }

    public void DeleteAvailableMoney(int amountSpentMoney)
    {
        _availableMoney -= amountSpentMoney;
    }

    public int ShowAvailableMoney()
    {
        return _availableMoney;
    }
}
