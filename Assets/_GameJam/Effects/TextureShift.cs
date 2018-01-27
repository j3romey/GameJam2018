using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureShift : MonoBehaviour
{

    public Material material;
    public Vector2 shift;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var a = material.mainTextureOffset;
        a += shift * Time.deltaTime;
        a.x = Mathf.Repeat(a.x, 1);
        a.y = Mathf.Repeat(a.y, 1);
        material.mainTextureOffset = a;
    }
}
