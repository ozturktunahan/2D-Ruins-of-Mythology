using UnityEngine;

public class camerafollow : MonoBehaviour
{   

    public GameObject targetObject;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    void LateUpdate()
    {
        targetedPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity , smoothTime);
    }
}
