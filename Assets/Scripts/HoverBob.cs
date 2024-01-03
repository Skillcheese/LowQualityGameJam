using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBob : MonoBehaviour
{
    [SerializeField]
    private float duration = 1;
    [SerializeField]
    private float distance = 1;
    private Vector3 startPos;
    private float time;
    private void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        time += Time.deltaTime;
        float angle = time * Mathf.PI * 2 / duration;
        float alpha = (Mathf.Sin(angle) + 1) / 2;
        transform.position = Vector3.Lerp(startPos, startPos + Vector3.up * distance, alpha);
    }
}
