using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Button itemSlotButton;
    public ItemData item;
    public int index;
    public bool equipped;
    public int quantity = 1;

    private void Start()
    {
        icon.sprite = item.icon;
        itemSlotButton.onClick.AddListener(OnClickSlot);
    }

    public void UpdateSlot()
    {
        quantityText.text = quantity.ToString();
    }

    private void OnClickSlot()
    {
        UIManager.Instance.InventoryUI.currentSlot = this;
        UIManager.Instance.InventoryUI.ActiveItemInfo();
    }
}
