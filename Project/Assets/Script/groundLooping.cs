using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundLooping : MonoBehaviour
{
    [Range(0, 3f)]
    public float scrollSpeed = 2.5f;
    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
