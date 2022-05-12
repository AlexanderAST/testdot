using UnityEngine;
 
public class Myss : MonoBehaviour
{

    private Vector3 MousePos;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MousePos = Input.mousePosition;
            Debug.Log(MousePos);
        }
    }
}
