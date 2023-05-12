using UnityEngine;

public class Slot : MonoBehaviour
{
    public int index;
    private Draggable occupyingObject;

    public bool IsOccupied => occupyingObject != null;

    public void SetOccupyingObject(Draggable obj)
    {
        occupyingObject = obj;
    }

    public bool IsOccupiedBy(Draggable obj)
    {
        return occupyingObject == obj;
    }

    public bool HasCorrectObject()
    {
        if (occupyingObject == null)
            return false;

        return occupyingObject.index == index;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Draggable draggable = collision.GetComponent<Draggable>();
        if (draggable != null)
        {
            draggable.SetCurrentSlot(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Draggable draggable = collision.GetComponent<Draggable>();
        if (draggable != null)
        {
            draggable.ClearCurrentSlot();
        }
    }
}