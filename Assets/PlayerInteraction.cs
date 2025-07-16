using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 1f; // 상호작용 가능한 거리
    public LayerMask interactableLayer; // 감지할 대상 (예: Interactable Layer)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, interactionRange, interactableLayer);

            if (hit.collider != null)
            {
                IInteractable target = hit.collider.GetComponent<IInteractable>();
                target?.Interact(); // 냉장고의 Interact() 실행됨!
            }
        }
    }
}
