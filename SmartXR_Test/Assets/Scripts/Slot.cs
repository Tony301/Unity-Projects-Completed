using UnityEngine;

public class Slot : MonoBehaviour
{
    public int index;
    private Draggable occupyingObject;

    public bool IsOccupied => occupyingObject != null;

    public bool TryOccupy(Draggable obj)
    {
        if (IsOccupied)
        {
            return false;
        }

        occupyingObject = obj;
        return true;
    }

    public void FreeSlot()
    {
        if (occupyingObject != null)
        {
            occupyingObject = null;
        }
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
}
