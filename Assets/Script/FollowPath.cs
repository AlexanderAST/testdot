using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovmentType
    {
        Moveing,
        Lerping
    }
    public MovmentType Type = MovmentType.Moveing;
    public MovingPAs MyPAs;
    public float speed = 1;
    public float maxDist = .1f;

    private IEnumerator<Transform> pointInPAth;



   
    void Start()
    {
        if (MyPAs==null)
        {
            Debug.Log("Путь не указал дядя");
            return;
        }
        pointInPAth = MyPAs.GetNextPathPoint();
        pointInPAth.MoveNext();
        if (pointInPAth.Current==null)
        {
            Debug.Log("Нужны точки");
            return;
        }
        transform.position = pointInPAth.Current.position;
    }

    
    void Update()
    {
        if (pointInPAth==null|| pointInPAth.Current==null)
        {
            return;
        }
        if (Type == MovmentType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPAth.Current.position, Time.deltaTime*speed);
        }
        else if (Type == MovmentType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPAth.Current.position, Time.deltaTime * speed);
        }

        var distanceSquare = (transform.position - pointInPAth.Current.position).sqrMagnitude;
        if (distanceSquare<maxDist*maxDist)
        {
            pointInPAth.MoveNext();
        }
    }
}
