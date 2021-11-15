using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace CustomStatExtension.Utils
{
    public class CustomStatManager : MonoBehaviour
    {
        /// <summary>
        /// Static reference of the class for accessiblity purposes.
        /// </summary>
        public static CustomStatManager instance { get; private set; }

        private Dictionary<string, object> customStatDefault = new Dictionary<string, object>();
        internal Dictionary<string, Func<object, object, object>> customStatApplyStatsOperation = new Dictionary<string, Func<object, object, object>>();
        private List<string> registeredStats = new List<string>();

        private void Start()
        {
            instance = this;
        }

        /// <summary>
        /// Registers a stat with the Custom Stat Manager for automated usage.
        /// </summary>
        /// <param name="name">The name of the stat.</param>
        /// <param name="defaultValue">The default value the stat should have on the player.</param>
        /// <param name="applyStatsOperation">The operation run in ApplyCardStats to transfer the values from the card to the player. First input is the player's current value, second input is the value on the card.</param>
        /// <returns>Returns true if the stat was added, and false if a stat with that name already existed.</returns>
        public bool RegisterStat(string name, object defaultValue, Func<object, object, object> applyStatsOperation)
        {
            if (registeredStats.Contains(name))
            {
                return false;
            }

            registeredStats.Add(name);
            customStatDefault.Add(name, defaultValue);
            customStatApplyStatsOperation.Add(name, applyStatsOperation);

            return true;
        }

        /// <summary>
        /// The currently registered stats and their default values.
        /// </summary>
        public ReadOnlyDictionary<string, object> RegisteredStats
        {
            get
            {
                return new ReadOnlyDictionary<string,object>(customStatDefault);
            }
        }
    }
}
