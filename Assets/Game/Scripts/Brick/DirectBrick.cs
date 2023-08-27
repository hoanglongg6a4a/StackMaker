using System.Collections.Generic;
using UnityEngine;

public class DirectBrick : Brick
{
    [SerializeField] List<Vector3> direction;
    public override void Handle()
    {
        if (meshRenderer.enabled == true)
        {
            meshRenderer.enabled = false;
        }
    }
    public Vector3 CheckDirection(Vector3 direct)
    {
        if (direct == direction[0])
        {
            return direction[1];
        }
        else
        {
            return -direction[0];
        }
    }
}
