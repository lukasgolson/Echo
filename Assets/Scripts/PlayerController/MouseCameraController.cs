﻿using UnityEngine;

public class MouseCameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 5.0f;
    [SerializeField] private float smoothing = 2.0f;
    [SerializeField] private GameObject character;
    private Vector2 _mouseLook;
    private Vector2 _smoothV;


    private void Start()
    {
        character = transform.parent.gameObject;
    }


    private void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        _smoothV.x = Mathf.Lerp(_smoothV.x, md.x, 1f / smoothing);
        _smoothV.y = Mathf.Lerp(_smoothV.y, md.y, 1f / smoothing);
        _mouseLook += _smoothV;

        transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, character.transform.up);
    }
}