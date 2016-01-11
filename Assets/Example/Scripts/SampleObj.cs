﻿using UnityEngine;
using PixelEditor;

public class SampleObj : MonoBehaviour
{
    GameObject pixelArtGenShape;

    void Start()
    {
        pixelArtGenShape = Instantiate(Resources.Load("Prefabs/PixelEditorShape")) as GameObject;
        pixelArtGenShape.GetComponent<Shape>().
            Init(gameObject, GetComponent<Generator>().Generate());
    }

    void Update()
    {
        var moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        var force = 1000f;
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(moveDir * force * Time.deltaTime);
        if (moveDir.sqrMagnitude > 0.1)
        {
            float zf = 0;
            float zAngle = Mathf.SmoothDampAngle
                (rb.rotation, Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg, ref zf, 0.1f);
            rb.rotation = zAngle;
        }
    }
}
