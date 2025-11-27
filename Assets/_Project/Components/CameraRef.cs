using System;
using UnityEngine;

namespace _Project.Components
{
    [Serializable]
    public struct CameraRef
    {
        public Camera camera;

        [Tooltip("distance between player and camera")]
        public Vector3 gapToPlayer;
        
        public Vector3 rotation;
        
        
    }
}