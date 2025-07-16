using UnityEngine;

public class Fridge : MonoBehaviour, IInteractable {
    public void Interact() {
        Debug.Log("냉장고와 상호작용!");
        UIManager.Instance.OpenItemPanel(); // UI 열기
    }
}
