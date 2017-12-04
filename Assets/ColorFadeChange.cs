using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFadeChange : MonoBehaviour {
    private Renderer renderer;
    public Color lerpedColor = Color.white;
    public bool Yo;
    private void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }
    void Update()
    {
        if (Yo)
        {
            lerpedColor = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time*1.2f, 1));
            renderer.material.color = lerpedColor;
            return;
        }
    }
    public void stop()
    {
        Yo = false;
        renderer.material.color = Color.white;   
    }
}
