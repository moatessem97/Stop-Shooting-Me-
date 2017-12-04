using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraQuake : MonoBehaviour
{

    public float Strength;
    public float Duration;
    public Transform camera;
    public bool Shake = false;

    Vector3 StartPos;
    float initialTime;
    // Use this for initialization
    void Start()
    {
        camera = Camera.main.transform;
        StartPos = camera.localPosition;
        initialTime = Duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Shake)
        {
            if (Duration > 0)
            {
                camera.localPosition = StartPos + Random.insideUnitSphere * Strength;
                Duration -= Time.deltaTime;
            }
            else
            {
                Shake = false;
                Duration = initialTime;
                camera.localPosition = StartPos;
            }
        }
    }
}
