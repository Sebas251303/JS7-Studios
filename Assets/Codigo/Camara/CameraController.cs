using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform target; // Aquí pondremos a tu Jugador

    [Header("Ajustes de Movimiento")]
    [Range(1f, 10f)]
    public float smoothFactor = 5f; // Qué tan suave persigue al dragón
    public Vector3 offset = new Vector3(0f, 1.5f, -10f); // Para que no apunte a los pies, sino un poco más arriba

    [Header("Límites del Mapa (Bordes)")]
    public bool useLimits = true;
    public Vector2 minLimits; // El borde izquierdo y de abajo
    public Vector2 maxLimits; // El borde derecho y de arriba

    // Usamos LateUpdate en lugar de Update para la cámara. 
    // Esto asegura que el jugador se mueva primero, y la cámara lo siga después, evitando temblores.
    void LateUpdate()
    {
        // Si no hay objetivo asignado, no hacemos nada
        if (target == null) return;

        // 1. Calculamos a dónde debería ir la cámara
        Vector3 targetPosition = target.position + offset;

        // 2. Si activamos los límites, encerramos la posición deseada dentro de esa caja
        if (useLimits)
        {
            targetPosition.x = Mathf.Clamp(targetPosition.x, minLimits.x, maxLimits.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minLimits.y, maxLimits.y);
        }

        // 3. Movemos la cámara suavemente hacia esa posición
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
    }
}