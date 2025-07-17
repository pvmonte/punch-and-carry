using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    [SerializeField] private TMP_Text _fpsDisplay;
    private int _fps;

    private async void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        _fps = Mathf.CeilToInt(1 / Time.unscaledDeltaTime);
        
        _fpsDisplay.text = $"{_fps.ToString()} FPS";
    }
}
