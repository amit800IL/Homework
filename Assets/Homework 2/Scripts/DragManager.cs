using UnityEngine;

public class DragManager : MonoBehaviour
{

    [SerializeField] Transform Camera;

    public bool canDrag;


    Vector3 Offset;

    private void Start()
    {
        canDrag = true;
    }


    private void OnMouseDown()
    {
        if (!canDrag)
        {
            return;
        }

        Vector3 mouse_position = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse_position.z = transform.position.z;
        Offset = mouse_position - transform.position;




    }

    private void OnMouseDrag()
    {
        if (!canDrag)
        {
            return;
        }

        Vector3 new_position = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        new_position.z = transform.position.z;
        transform.position = new_position - Offset;


    }

}
