using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    [ExecuteAlways]
    public class MenuRect : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer lineRenderer;
        [SerializeField]
        private float DepthDraw;

        [SerializeField]
        private bool debugMode;

        [SerializeField]
        private Vector3 center;
        [SerializeField]
        [Min(0)]
        private float leftSize;
        [SerializeField]
        [Min(0)]
        private float rightSize;
        [SerializeField]
        [Min(0)]
        private float topSize;
        [SerializeField]
        [Min(0)]
        private float bottomSize;

        public bool DebugMode { get => debugMode; private set => debugMode = value; }
        public Vector3 Center { get => center; private set => center = value; }
        public float LeftSize { get => leftSize; private set => leftSize = value; }
        public float RightSize { get => rightSize; private set => rightSize = value; }
        public float TopSize { get => topSize; private set => topSize = value; }
        public float BottomSize { get => bottomSize; private set => bottomSize = value; }


        public void Start()
        {            
            lineRenderer.enabled = debugMode;
            if (debugMode)
            {
                var obj = PositionToBorders();
                
                BordersToLineRenderer(obj, lineRenderer);
            }

        }

        public void Update()
        {
            #if UNITY_EDITOR
            lineRenderer.enabled = debugMode;
            if (Application.IsPlaying(gameObject) == false)
                if (debugMode)
                {
                    var obj = PositionToBorders();
                    BordersToLineRenderer(obj, lineRenderer);
                }

            #endif
        }

        public Borders PositionToBorders()
        {            
            Borders result = new
                (
                new Vector3(center.x + RightSize, center.y + TopSize , DepthDraw),
                new Vector3(center.x - LeftSize, center.y + TopSize, DepthDraw),
                new Vector3(center.x - LeftSize, center.y - BottomSize, DepthDraw),
                new Vector3(center.x + RightSize, center.y - BottomSize , DepthDraw)
                ); 
            return result;
        }

        private static void BordersToLineRenderer(Borders Borders, LineRenderer Line)
        {
            Line.loop = true;
            Line.positionCount = 4;
            Line.SetPosition(0, Borders.LeftTop);
            Line.SetPosition(1, Borders.RightTop);
            Line.SetPosition(2, Borders.RightLower);
            Line.SetPosition(3, Borders.LeftLower);
        }

    }
}
