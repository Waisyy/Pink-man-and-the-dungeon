using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public static CoinSystem Instance;
    
    public int playerCoins = 0;
    public int PlayerCoins => playerCoins; // Публичное свойство только для чтения

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCoins();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        playerCoins += amount;
        SaveCoins();
    }

    public bool SpendCoins(int amount)
    {
        if (CanAfford(amount))
        {
            playerCoins -= amount;
            SaveCoins();
            return true;
        }
        return false;
    }

    public bool CanAfford(int amount)
    {
        return playerCoins >= amount;
    }

    void SaveCoins()
    {
        PlayerPrefs.SetInt("PlayerCoins", playerCoins);
    }

    void LoadCoins()
    {
        playerCoins = PlayerPrefs.GetInt("PlayerCoins", 0);
    }
}