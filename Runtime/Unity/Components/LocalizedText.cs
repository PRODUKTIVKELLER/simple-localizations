﻿using Produktivkeller.SimpleLocalization.Unity.Core;
using TMPro;
using UnityEngine;

namespace Produktivkeller.SimpleLocalization.Unity.Components
{
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizedText : MonoBehaviour, ILocalized
    {
        public string translationKey;

        private TMP_Text _text;

        private void Start()
        {
            ResolveLocalization();
        }

        private void OnEnable()
        {
            ResolveLocalization();
        }

        public void OnLanguageHasChanged()
        {
            ResolveLocalization();
        }

        private void ResolveLocalization()
        {
            if (_text == null)
            {
                _text = GetComponent<TMP_Text>();
            }

            // Check is required because "OnEnable" can be called before LanguageService is initialized.
            if (!LocalizationService.Instance)
            {
                return;
            }

            if (translationKey.Length > 0)
            {
                _text.text = LocalizationService.Instance.ResolveLocalizationKey(translationKey);
            }

            LocalizationService.Instance.UpdateFont(gameObject);
        }
    }
}