using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCounter : MonoBehaviour
{
    private float deltaTime = 0f;

    [SerializeField, Range(1, 100)]
    private int size = 25;

    [SerializeField]
    private Color color = Color.green;

    private int fpsMode = 0;
    public bool isShow;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    //Update is called once per frame
    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isShow = !isShow;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (fpsMode == 0)
                Application.targetFrameRate = 30;
            if (fpsMode == 1)
                Application.targetFrameRate = 45;
            if (fpsMode == 2)
                Application.targetFrameRate = 60;
            if (fpsMode == 3)
                Application.targetFrameRate = 120;
            fpsMode = (fpsMode+1) % 4;
        }
    }

    private void OnGUI()
    {
        if (isShow)
        {
            GUIStyle style = new GUIStyle();
            int w = Screen.width, h = Screen.height;
            Rect rect = new Rect(30, 30, Screen.width, Screen.height);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 4 / 100;
            style.normal.textColor = color;

            float ms = deltaTime * 1000f;
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0.} FPS ({1:0.0} ms)", fps, ms);

            GUI.Label(rect, text, style);
        }
    }
}
