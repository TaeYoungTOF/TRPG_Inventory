using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : BaseUI
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unEquipButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button dropButton;

    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemInfoName;
    [SerializeField] private TextMeshProUGUI itemInfoDescription;
    [SerializeField] private TextMeshProUGUI itemInfoAtk;
    [SerializeField] private TextMeshProUGUI itemInfoDef;
    [SerializeField] private TextMeshProUGUI itemInfoHp;
    [SerializeField] private TextMeshProUGUI itemInfoCrit;

    [SerializeField] private GameObject itemInfo;
    [SerializeField] private List<ItemSlot> slots;
    [SerializeField] public ItemSlot currentSlot;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform content;
    
    public override void Init()
    {
        itemInfo.SetActive(false);
        backButton.onClick.AddListener(OnClickBackButton);
    }

    private void OnClickBackButton()
    {
        itemInfo.SetActive(false);
        UIManager.Instance.MainUI.ToggleButton(true);

        gameObject.SetActive(false);
    }

    public void ActiveItemInfo()
    {
        equipButton.gameObject.SetActive(false);
        unEquipButton.gameObject.SetActive(false);
        useButton.gameObject.SetActive(false);
        dropButton.gameObject.SetActive(true);

        UpdateItemInfo();

        itemInfo.SetActive(true);

        if (currentSlot.item.itemtype == ItemType.Equipable)
        {
            equipButton.gameObject.SetActive(!currentSlot.equipped);
            unEquipButton.gameObject.SetActive(currentSlot.equipped);
        }
        else if (currentSlot.item.itemtype == ItemType.Consumable)
        {
            useButton.gameObject.SetActive(true);
        }
    }

    private void UpdateItemInfo()
    {
        itemIcon.sprite = currentSlot.item.icon;
        itemInfoName.text = currentSlot.item.itemName;
        itemInfoDescription.text = currentSlot.item.description;
        itemInfoAtk.text = currentSlot.item.atkValue.ToString();
        itemInfoDef.text = currentSlot.item.defValue.ToString();
        itemInfoHp.text = currentSlot.item.hpValue.ToString();
        itemInfoCrit.text = currentSlot.item.critValue.ToString();
    }

    public void CreateNewSlot(ItemData data)
    {
        GameObject newSlotObject = Instantiate(itemSlotPrefab, content);
        ItemSlot newSlot = newSlotObject.GetComponent<ItemSlot>();

        newSlot.item = data;
        newSlot.index = slots.Count;

        newSlot.UpdateSlot();
        slots.Add(newSlot);
    }

    /**Todo 중복 아이템 획득 처리*/
}
