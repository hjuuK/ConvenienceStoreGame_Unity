using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Transform originalParent;
    private Vector3 originalPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.position;
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root); // canvas 최상위로 올림
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
{
    GameObject target = eventData.pointerEnter;

    Transform targetSlot = target?.transform;
    while (targetSlot != null && targetSlot.name != "Grid")
    {
        if (targetSlot.name.Contains("ItemSlot"))
            break;
        targetSlot = targetSlot.parent;
    }

    if (targetSlot != null && targetSlot.name.Contains("ItemSlot") && targetSlot != transform)
    {
        transform.SetParent(targetSlot);
        rectTransform.position = targetSlot.position;
    }
    else
    {
        ResetPosition();
    }

    canvasGroup.blocksRaycasts = true;
}


    void ResetPosition()
    {
        transform.SetParent(originalParent);
        rectTransform.position = originalPosition;
    }
}
