using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerLevel;
    [SerializeField] private TextMeshProUGUI playerDescription;
    [SerializeField] private TextMeshProUGUI playerGold;

    public override void Init()
    {
        ToggleButton(true);

        statusButton.onClick.AddListener(OnClickStatusButton);
        inventoryButton.onClick.AddListener(OnClickInventoryButton);
    }

    public void UpdateUI()
    {
        playerName.text = GameManager.Instance.player.PlayerName;
        playerLevel.text = GameManager.Instance.player.PlayerLevel.ToString();
        playerDescription.text = GameManager.Instance.player.PlayerDescription;
        playerGold.text = GameManager.Instance.player.PlayerGold.ToString();
    }

    public void ToggleButton(bool state)
    {
        statusButton.gameObject.SetActive(state);
        inventoryButton.gameObject.SetActive(state);

        UpdateUI();
    }

    private void OnClickStatusButton()
    {
        ToggleButton(false);

        UIManager.Instance.OpenStatusUI();
    }

    private void OnClickInventoryButton()
    {
        ToggleButton(false);

        UIManager.Instance.OpenInventoryUI();
    }
}
