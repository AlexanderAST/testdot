using UnityEngine;
public class Unit : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float speed;
    private float progress;


    void Start()
    {
        transform.position = startPosition;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(startPosition, endPosition, progress);
        progress += speed;
        

    }
}


