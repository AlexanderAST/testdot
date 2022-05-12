using System.Collections.Generic;
using UnityEngine;

public class MovingPAs : MonoBehaviour
{
    public enum PathTypes
    {
        Linear,
        loop
    }
    public PathTypes PathType;
    public int movmentDir = 1;
    public int MoveingTo = 0;
    public Transform[] PathEl;
    public void OnDrawGizmos()
    {
        if (PathEl == null || PathEl.Length <2)
        {
            return;
        }
        for (var i = 1; i < PathEl.Length; i++)
        {
            Gizmos.DrawLine(PathEl[i - 1].position, PathEl[i].position);
        }
        if (PathType==PathTypes.loop)
        {
            Gizmos.DrawLine(PathEl[0].position, PathEl[PathEl.Length - 1].position);
        }
    }
    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathEl==null || PathEl.Length<1)
        {
            yield break;
        }
        while (true)
        {
            yield return PathEl[MoveingTo];
            if (PathEl.Length==1)
            {
                continue;
            }
            if (PathType==PathTypes.Linear)
            {
                if (MoveingTo<=0)
                {
                    movmentDir = 1;
                }
                else if (MoveingTo>= PathEl.Length-1)
                {
                    movmentDir = -1;
                }
                MoveingTo = MoveingTo + movmentDir;

                if (PathType==PathTypes.loop)
                {
                    if (MoveingTo>=PathEl.Length)
                    {
                        MoveingTo = 0;
                    }
                    if (MoveingTo<0)
                    {
                        MoveingTo = PathEl.Length - 1;
                    }
                }
            }
        }
    }
}
