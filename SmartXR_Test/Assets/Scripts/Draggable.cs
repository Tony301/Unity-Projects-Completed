using UnityEngine;

public class Draggable : MonoBehaviour
{
    public int index;

    private bool isDragging = false;
    private Vector3 offset;
    private Slot currentSlot; // store the slot that the object is currently over

    private void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetWorldPosition() + offset;
            newPosition.z = 0; // keep the object at the same z-position
            transform.position = newPosition;
        }
    }

    private Vector3 GetWorldPosition()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                return Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
        }
        else
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        return Vector3.zero;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetWorldPosition();

        // If this object is occupying a slot, clear it
        if (currentSlot != null && currentSlot.IsOccupiedBy(this))
        {
            currentSlot.SetOccupyingObject(null);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // If the object is released over a slot, snap it to the slot
        if (currentSlot && !currentSlot.IsOccupied)
        {
            Vector3 slotPosition = currentSlot.transform.position;
            slotPosition.z = -1; // set a fixed Z position to ensure it appears on top
            transform.position = slotPosition;
            currentSlot.SetOccupyingObject(this);
        }
    }

    // Called when the object enters a slot's area
    public void SetCurrentSlot(Slot slot)
    {
        currentSlot = slot;
    }

    // Called when the object leaves a slot's area
    public void ClearCurrentSlot()
    {
        currentSlot = null;
    }
}
