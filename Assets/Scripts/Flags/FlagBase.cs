using UnityEngine;

public class FlagBase : MonoBehaviour
{
    protected static bool HasFlag<T>(GameObject g)
    where T: Component
    {
        if (g.GetComponent<T>() != null)
        {
            return true;
        }
        if (g.GetComponentInParent<T>() != null)
        {
            return true;
        }
        return false;
    } 
}
