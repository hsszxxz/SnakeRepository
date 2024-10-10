using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraControl : MonoBehaviour
{
    private Transform head1;
    private Transform head2;
    private Vector3 velocity = Vector3.zero;
    [Range(0f, 1f)]
    public float smoothTime;

    public Vector3 positionOffset;
    private void Awake()
    {
        StartCoroutine(LateAwake());
    }
    IEnumerator LateAwake()
    {
        yield return null;
        head1 = GameObject.Find("Head1(Clone)").transform;
        head2 = GameObject.Find("Head2(Clone)").transform;
    }
    private void LateUpdate()
    {
        Vector3 target = new Vector3((head1.position.x + head2.position.x) / 2, (head1.position.y + head2.position.y) / 2, 0) + positionOffset;
        transform.position = Vector3.SmoothDamp(transform.position, target,ref velocity,smoothTime);
    }
}
