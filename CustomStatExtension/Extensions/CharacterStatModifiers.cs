using System;
using System.Collections.Generic;
using CustomStatExtension.Utils;

namespace CustomStatExtension.Extensions
{
    [Serializable]
    public class CustomStatsData
    {
        public Dictionary<string, object> data;

        public CustomStatsData()
        {
            data = new Dictionary<string, object>();
            foreach (var stat in CustomStatManager.instance.RegisteredStats)
            {
                data.Add(stat.Key, stat.Value);
            }
        }
    }
}
