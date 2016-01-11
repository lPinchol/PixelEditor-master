using UnityEngine;

namespace PixelEditor
{
    public class PixelPerfectCamera : MonoBehaviour
    {
        public float pixelsPerUnit = 100;

        void Awake()
        {
            var cam = GetComponent<Camera>();
            cam.orthographicSize = Screen.height / pixelsPerUnit / 2;
        }
    }
}
