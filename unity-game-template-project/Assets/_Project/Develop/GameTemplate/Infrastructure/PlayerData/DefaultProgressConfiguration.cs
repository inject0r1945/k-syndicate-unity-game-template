using GameTemplate.Services.Wallet;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameTemplate.Infrastructure.Data
{
    [CreateAssetMenu(fileName = "new DefaultProgressConfiguration", menuName = "GameTemplate/Progress/DefaultProgressConfiguration")]
    public class DefaultProgressConfiguration : ScriptableObject
    {
        [ValidateInput(nameof(IsUniqueCurrency))]
        [ValidateInput(nameof(IsNotNone))]
        [SerializeField] private List<CurrencyValue> _currencyValues;

        public Dictionary<int, long> WalletsData => _currencyValues.ToDictionary(x => (int)x.CurrencyType, x => x.Amount);

        private bool IsUniqueCurrency(List<CurrencyValue> _currencyValues, ref string errorMessage)
        {
            errorMessage = "Currencies is not unique";

            return _currencyValues.GroupBy(x => x.CurrencyType).Count() == _currencyValues.Count();
        }

        private bool IsNotNone(List<CurrencyValue> _currencyValues, ref string errorMessage)
        {
            errorMessage = "None value cannot be used";

            return _currencyValues.Where(x => x.CurrencyType == CurrencyType.None).Count() == 0;
        }
    }
}
