﻿// <copyright file="ModSettings.cs" company="algernon (K. Algernon A. Sheppard)">
// Copyright (c) algernon (K. Algernon A. Sheppard). All rights reserved.
// Licensed under the Apache Licence, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace PlopTheGrowables
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;

    /// <summary>
    /// The mod's settings.
    /// </summary>
    [FileLocation(Mod.ModName)]
    public class ModSettings : ModSetting
    {
        private bool _disableLevelling = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModSettings"/> class.
        /// </summary>
        /// <param name="mod"><see cref="IMod"/> instance.</param>
        public ModSettings(IMod mod)
            : base(mod)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether building levelling should be disabled.
        /// </summary>
        public bool DisableLevelling
        {
            get => _disableLevelling;

            set
            {
                _disableLevelling = value;

                // Assign contra value to ensure that JSON contains at least one non-default value.
                Contra = value;

                // Update system, if it's ready.
                if (HistoricalLevellingSystem.Instance is HistoricalLevellingSystem historicalLevellingSystem)
                {
                    historicalLevellingSystem.DisableLevelling = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether, well, nothing really.
        /// This is just the inverse of <see cref="DisableLevelling"/>, to ensure the the JSON contains at least one non-default value.
        /// This is to workaround a bug where the settings file isn't overwritten when there are no non-default settings.
        /// </summary>
        [SettingsUIHidden]
        public bool Contra { get; set; } = true;

        /// <summary>
        /// Restores mod settings to default.
        /// </summary>
        public override void SetDefaults()
        {
            _disableLevelling = false;
        }
    }
}