using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : BaseUI
{
    [SerializeField] private Button backButton;

    [SerializeField] private TextMeshProUGUI atk;
    [SerializeField] private TextMeshProUGUI def;
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private TextMeshProUGUI crit;

    public override void Init()
    {
        backButton.onClick.AddListener(OnClickBackButton);
    }

    public void UpdateUI()
    {
        atk.text = GameManager.Instance.player.Atk.ToString();
        def.text = GameManager.Instance.player.Def.ToString();
        hp.text = GameManager.Instance.player.Hp.ToString();
        crit.text = GameManager.Instance.player.Crit.ToString();
    }

    private void OnClickBackButton()
    {
        UIManager.Instance.MainUI.ToggleButton(true);

        gameObject.SetActive(false);
    }
}
