using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject itemPanel; // 냉장고 아이템 선택 UI 패널

    void Awake()
    {
        Instance = this;
    }

    public void OpenItemPanel()
    {
        itemPanel.SetActive(true);
    }

    public void CloseItemPanel()
    {
        itemPanel.SetActive(false);
    }
}
