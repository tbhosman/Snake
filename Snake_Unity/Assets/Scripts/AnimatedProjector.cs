using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimatedProjector : MonoBehaviour
{
    public float fps = 60.0f;
    public List<Texture2D> frames;
    private int frameIndex;
    private Projector projector;

    void Start()
    {
        //frames = (Texture2D[])Resources.LoadAll("Caustics_png");
        projector = (Projector)GetComponent("Underwater effect");
        InvokeRepeating("NextFrame", 0, 1 / fps);
        frameIndex = 0;
    }

    void NextFrame()
    {
        projector.material.SetTexture("_MainTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Count;
    }
}