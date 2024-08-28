using Sirenix.OdinInspector;

using UnityEngine;

namespace GameTemplate.Services.SaveLoad
{
    [CreateAssetMenu(fileName = "new SaveConfiguration", menuName = "GameTemplate/Saves/EasySaveConfiguration")]
    public class SaveConfiguration : ScriptableObject
    {
        [SerializeField] private bool _isEnableEncryption;

        [ShowIf(nameof(_isEnableEncryption))]
        [SerializeField] private string _password;

        [SerializeField] private string _saveKey = "PlayerProgress";

        public string SaveKey => _saveKey;

        public bool IsEnableEncryption => _isEnableEncryption;    

        public string Password => _password;
    }
}
