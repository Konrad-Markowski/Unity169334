using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePosition3D : MonoBehaviour
{
   [SerializeField] private Camera mainCamera;
   [SerializeField] private LayerMask layerMask;

   private void Update()
   {
       Vector2 mousePos = Mouse.current.position.ReadValue();
       Ray ray = mainCamera.ScreenPointToRay(mousePos);
       if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask)){
            // Debug.Log($"Pozycja myszki w świecie: {raycastHit.point}");
        }
   }
}
