using UnityEngine;

public class IsometricCameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(-10, 15, -10);
    public float smoothSpeed = 0.1f; 

    void LateUpdate()
    {
        if (player != null)
        {
           
            Vector3 desiredPosition = player.position + offset;

           
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            
            transform.position = smoothedPosition;

            
            transform.LookAt(player);
        }
    }
}