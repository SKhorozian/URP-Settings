using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

namespace URPSettings
{
    public class URPSettingsUI : MonoBehaviour
    {
        [SerializeField] URPSettingsManager settingsManager;

        //Quality
        [Space (10)]
        [SerializeField] Dropdown qualityDropdown;

        //HDR toggle
        [Space (10)]
        [SerializeField] Toggle HDRToggle;

        //Render Scale
        [Space (10)]
        [SerializeField] Slider renderScaleSlider;
        [SerializeField] Text renderScaleValue;

        //Shadow Distance
        [Space (10)]
        [SerializeField] Slider shadowDistanceSlider;
        [SerializeField] Text shadowDistanceValue;

        //Anti-Aliasing
        [Space (10)]
        [SerializeField] Dropdown antiAliasingDropdown;


        void Awake () {
            if (!settingsManager)
                Debug.LogError ("Settings Manager reference not found");
        }
        
        public void SetPipelineQuality () {
            settingsManager.SetQuality (qualityDropdown.value);
        }

        public void ChangeUseHDR () {
            settingsManager.ChangeUseHDR (HDRToggle.isOn);
        }

        public void ChangeRenderScale () {
            renderScaleValue.text = settingsManager.ChangeRenderScale (renderScaleSlider.value).ToString ();
        }

        public void ChangeShadowDistance () {
            shadowDistanceValue.text = settingsManager.ChangeShadowDistance (shadowDistanceSlider.value).ToString () + " m";
        }

        public void ChangeAntiAliasing () {
            settingsManager.ChangeAntiAliasing ((int)Mathf.Pow (2, antiAliasingDropdown.value));
        }
        
    }
}
