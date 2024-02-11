using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFlag : FlagBase
{
    public static bool HasGround(GameObject g)
    {
        return HasFlag<GroundFlag>(g);
    }
}
