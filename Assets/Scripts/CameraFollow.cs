using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Personaje a seguir
    public float smoothSpeed = 0.1f;  // Suavidad del movimiento
    public float offsetY = -3f;  // Desplazamiento para mantener la cámara abajo

    private void LateUpdate()
    {
        if (target != null)
        {
            // Posición deseada con el personaje
            Vector3 targetPosition = new Vector3(target.position.x, offsetY, transform.position.z);

            // Movimiento suave de la cámara
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }
}
