using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private MainUI mainUI;
    public MainUI MainUI { get => mainUI; }
    [SerializeField] private StatusUI statusUI;
    public StatusUI StatusUI { get => statusUI; }
    [SerializeField] private InventoryUI inventoryUI;
    public InventoryUI InventoryUI { get => inventoryUI; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        statusUI.gameObject.SetActive(false);
        InventoryUI.gameObject.SetActive(false);

        mainUI.Init();
        statusUI.Init();
        InventoryUI.Init();
    }

    public void OpenStatusUI()
    {
        statusUI.UpdateUI();
        statusUI.gameObject.SetActive(true);
    }

    public void OpenInventoryUI()
    {
        InventoryUI.gameObject.SetActive(true);
    }
}
