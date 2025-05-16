using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem Instance;

    [Header("Настройки улучшений")]
    public int damageUpgradePrice = 10;
    public int damageBonus = 1;

    [Header("UI элементы")]
    public GameObject shopPanel;
    public Text damageUpgradeText;
    public Button damageUpgradeButton;
    public Text coinsText;

    public int currentDamageLevel = 1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadPlayerProgress();
        UpdateShopUI();
    }

    void LoadPlayerProgress()
    {
        currentDamageLevel = PlayerPrefs.GetInt("DamageLevel", 1);
    }

    public void ToggleShop()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
        if (shopPanel.activeSelf)
        {
            UpdateShopUI();
        }
    }

    void UpdateShopUI()
    {
        // Обновляем отображение монет через CoinSystem
        coinsText.text = $"Монеты: {CoinSystem.Instance.PlayerCoins}";
        damageUpgradeText.text = $"Урон: {currentDamageLevel} ур.\nЦена: {damageUpgradePrice}";

        // Проверяем, хватает ли монет
        damageUpgradeButton.interactable = CoinSystem.Instance.CanAfford(damageUpgradePrice);
    }

    public void BuyDamageUpgrade()
    {
        if (CoinSystem.Instance.SpendCoins(damageUpgradePrice))
        {
            currentDamageLevel += damageBonus;
            PlayerPrefs.SetInt("DamageLevel", currentDamageLevel);
            UpdateShopUI();
            Debug.Log($"Урон улучшен! Текущий уровень: {currentDamageLevel}");
        }
        else
        {
            Debug.Log("Недостаточно монет!");
        }
    }
}