using System.Collections.Generic;

namespace Dropsy.Tests
{
    public class FakeScreen : IScreen
    {
        private readonly List<string> _outputs = new List<string>();
        private int _currentKey;
        private List<int> _keys = new List<int>();

        public string LastOutput => _outputs[_outputs.Count - 1];

        public IReadOnlyList<string> Outputs => _outputs;

        public void WriteLine(string line)
        {
            _outputs[_outputs.Count - 1] += line + "\n";
        }

        public int ReadKey()
        {
            var retValue = _keys[_currentKey];
            if (_currentKey < _keys.Count - 1)
                _currentKey++;
            return retValue;
        }

        public void Clear()
        {
            _outputs.Add("");
        }

        public void Pause()
        {
        }

        public void SetNextkey(int key)
        {
            _currentKey = 0;
            _keys.Add(key);
        }

        public void QueueNextKeys(List<int> keys)
        {
            _keys = keys;
            _currentKey = 0;
        }
    }
}