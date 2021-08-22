using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace URPSettings
{
    public class ChangeURPOnTrigger : MonoBehaviour
    {
        [SerializeField] URPSettingsManager settingsManager;

        void OnAwake () {
            if (!settingsManager) 
                Debug.LogError ("Settings Manager reference not found");
        }

        void OnTriggerEnter (Collider other) {
            settingsManager.SetQuality (1);
        }
    }
}
