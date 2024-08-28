﻿using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameTemplate.Infrastructure.AssetManagement
{
    public interface IComponentAssetProvider
    {
        public UniTask<TAsset> LoadAsync<TAsset>(AssetReferenceGameObject assetReference) where TAsset : MonoBehaviour;

        public UniTask<TAsset> LoadByAddressAsync<TAsset>(string address) where TAsset : MonoBehaviour;

        public void Release(AssetReferenceGameObject assetReference);

        public void Release(string assetAddress);
    }
}