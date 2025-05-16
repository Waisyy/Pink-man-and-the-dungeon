using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            ShopSystem.Instance.ToggleShop();
        });
    }
}