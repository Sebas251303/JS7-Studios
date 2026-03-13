using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    [Header("Parametros")]
    public Transform player;
    public Vector3 offsetPosition;
    public float followSpeedPlayer = 2f;
    private bool followPlayer = true;

    void Update()
    {
        if (player != null && followPlayer)
        {
            Vector3 targetPosition = new Vector3(player.position.x + offsetPosition.x, player.position.y + offsetPosition.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeedPlayer * Time.deltaTime);
        }
    }

    public void IsFollowPlayer(bool value)
    {
        followPlayer = value;
    }
}
