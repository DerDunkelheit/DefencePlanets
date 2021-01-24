using System;
using UnityEngine;

namespace EarthDefendGame
{
    public class CameraResolution : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer backGround = null;

        private void Awake()
        {
            float size = backGround.size.y / 2f;

            Camera.main.orthographicSize = size;
        }
    }
}
