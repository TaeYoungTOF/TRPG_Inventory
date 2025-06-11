using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image equipedIcon;
    [SerializeField] private Button itemSlotButton;
    [SerializeField] private TextMeshProUGUI quantityText;
    public ItemData item;
    public int index;
    public bool equipped;
    public int quantity = 1;
    public Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void Start()
    {
        icon.sprite = item.icon;
        equipedIcon.gameObject.SetActive(false);
        outline.enabled = false;
        itemSlotButton.onClick.AddListener(OnClickSlot);

        if (item.itemtype == ItemType.Equipable)
        {
            quantityText.text = "";
        }
        else
        {
            quantityText.text = quantity.ToString();
        }
    }

    public void UpdateSlot()
    {
        if (equipped)
        {
            equipedIcon.gameObject.SetActive(true);
        }
        else
        {
            equipedIcon.gameObject.SetActive(false);
        }

        quantityText.text = quantity.ToString();
    }

    private void OnClickSlot()
    {
        UIManager.Instance.InventoryUI.currentSlot = this;
        UIManager.Instance.InventoryUI.ActiveItemInfo();
    }
}
