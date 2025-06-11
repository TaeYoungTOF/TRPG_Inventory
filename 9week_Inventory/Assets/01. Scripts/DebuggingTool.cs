using UnityEngine;
using UnityEngine.UI;

public class DebuggingTool : MonoBehaviour
{
    public ItemData swordData;
    public ItemData axData;
    public ItemData hpPotionData;

    public Button CreateSwordButton;
    public Button CreateAxButton;
    public Button CreateHpPotionButton;

    private void Start()
    {
        CreateSwordButton.onClick.AddListener(CreateSword);
        CreateAxButton.onClick.AddListener(CreateAx);
        CreateHpPotionButton.onClick.AddListener(CreateHpPotion);
    }

    private void CreateSword()
    {
        UIManager.Instance.InventoryUI.CreateNewSlot(swordData);
    }

    private void CreateAx()
    {
        UIManager.Instance.InventoryUI.CreateNewSlot(axData);
    }

    private void CreateHpPotion()
    {
        UIManager.Instance.InventoryUI.CreateNewSlot(hpPotionData);
    }
}
