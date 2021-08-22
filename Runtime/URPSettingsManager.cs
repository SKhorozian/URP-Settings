using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

namespace URPSettings
{
    public class URPSettingsManager : MonoBehaviour
    {
        [SerializeField] protected UniversalRenderPipelineAsset[] pipelineAssets;
        [SerializeField] protected UniversalRenderPipelineAsset customPipelineAsset;
        
        //Texture Quality
        public const int textureQualityMin = 1;
        public const int textureQualityMax = 5;

        //Render Scale
        public const float renderScaleMin = 0.3f;
        public const float renderScaleMax = 1f;

        //Shadows
        public const float shadowDistanceMin = 10f; //Metric
        public const float shadowDistanceMax = 50f; //Metric

        //Functions
        void Awake () {
            if (!customPipelineAsset)
                Debug.LogError ("Custom Pipeline Reference not set");
        }

        public void SetQuality (int n) {
            if (n < 0 || n > pipelineAssets.Length) return; //n has to be between 0 and the length of the options-1.

            ChangeUseHDR (pipelineAssets[n].supportsHDR);
            ChangeAntiAliasing (pipelineAssets[n].msaaSampleCount);
            ChangeRenderScale (pipelineAssets[n].renderScale);
            ChangeShadowDistance (pipelineAssets[n].shadowDistance);
        
            GraphicsSettings.renderPipelineAsset = pipelineAssets[n]; //Assign it to the Graphics Settings.
        }

        //These settings change the custom pipeline's values.
        public void ChangeUseHDR (bool value) {customPipelineAsset.supportsHDR = value; SetPipelineToCustom ();} 

        public int ChangeAntiAliasing (int value) {
            customPipelineAsset.msaaSampleCount = value;
            SetPipelineToCustom ();
            return customPipelineAsset.msaaSampleCount;
        }

        public float ChangeRenderScale (float value) {
            //Clamp the value between the min and the max values
            value = Mathf.Clamp (value, renderScaleMin, renderScaleMax); 
            customPipelineAsset.renderScale = value;
            SetPipelineToCustom ();
            return customPipelineAsset.renderScale;
        }

        //Metric
        public float ChangeShadowDistance (float value) {
            //Clamp the value between the min and the max values
            value = Mathf.Clamp (value, shadowDistanceMin, shadowDistanceMax);
            customPipelineAsset.shadowDistance = value;
            SetPipelineToCustom ();
            return customPipelineAsset.shadowDistance;
        }      

        //If the pipeline settings were changed manually.
        void SetPipelineToCustom () {
            GraphicsSettings.renderPipelineAsset = customPipelineAsset;
        }
    }
}
