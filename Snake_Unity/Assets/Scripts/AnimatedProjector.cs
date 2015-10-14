using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AnimatedProjector : MonoBehaviour
{
    public float fps = 60.0f;
    public List<Texture2D> frames;
    private int frameIndex;
    public Projector projector;

    void Start()
    {
        projector = GetComponent<Projector>();
        frames = frames.OrderBy(go => go.ToString()).ToList();
        InvokeRepeating("NextFrame", 0, 1 / fps); //keep repeating NextFrame() every 1/fps seconds
    }

    void NextFrame()
    {
        projector.material.SetTexture("_ShadowTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Count;
    }
}