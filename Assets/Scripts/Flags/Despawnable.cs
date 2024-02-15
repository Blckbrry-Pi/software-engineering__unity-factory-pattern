using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawnable : FlagBase
{
    public static bool IsDespawnable(GameObject g)
    {
        return HasFlag<Despawnable>(g);
    }
}
