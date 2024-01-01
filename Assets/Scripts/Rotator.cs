using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Tooltip("This can speed up and decrease the speed the coin rotates on")]
    [SerializeField][Range(50, 100)] float  rotateSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, 1 * Time.deltaTime * rotateSpeed);
    }
}
