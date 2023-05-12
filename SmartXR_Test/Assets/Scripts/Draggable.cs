using UnityEngine;

public class Draggable : MonoBehaviour
{
    public int index;

    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;
    private Slot closestSlot;  // Store the closest slot

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = 0;
            transform.position = newPosition;

            // Update the closest slot
            closestSlot = FindClosestSlot();
        }
    }

    private Slot FindClosestSlot()
    {
        Slot[] slots = FindObjectsOfType<Slot>();
        Slot closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Slot slot in slots)
        {
            float distance = Vector3.Distance(transform.position, slot.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = slot;
            }
        }

        return closest;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        // Free the slot this object was occupying
        if (closestSlot && closestSlot.IsOccupiedBy(this))
        {
            closestSlot.FreeSlot();
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // If the object is released close to a slot, snap it to the slot
        if (closestSlot && closestSlot.TryOccupy(this))
        {
            Vector3 slotPosition = closestSlot.transform.position;
            slotPosition.z = -1;
            transform.position = slotPosition;
        }
        else
        {
            transform.position = originalPosition;
        }
    }
}
