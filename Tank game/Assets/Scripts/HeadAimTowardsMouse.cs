using UnityEngine;
using UnityEngine.InputSystem;

public class HeadAimTowardsMouse : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform tankHead; 
    [SerializeField] public float rotationSpeed = 200f;

    private Vector3 mouseWorldPosition;

    void Update()
    {
        GetMouseWorldPosition();
        RotateHeadTowardsMouse();
    }

    private void GetMouseWorldPosition()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = mainCamera.ScreenPointToRay(mousePos);
        
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 1000f, layerMask))
        {
            mouseWorldPosition = raycastHit.point;
        }
    }

    private void RotateHeadTowardsMouse()
    {
        if (tankHead == null) return;

        Vector3 directionToMouse = mouseWorldPosition - tankHead.position;
        directionToMouse.y = 0; 

        if (directionToMouse.sqrMagnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);
            tankHead.rotation = Quaternion.RotateTowards(
                tankHead.rotation, 
                targetRotation, 
                rotationSpeed * Time.deltaTime
            );
        }
    }
}