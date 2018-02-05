using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE62___Cubic_permutations
{
    public class CustomDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public List<TKey> CustomKeys { get; private set; }

        public CustomDictionary()
            : base()
        {
            CustomKeys = new List<TKey>();
        }

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            CustomKeys.Add(key);
        }
    }
}
