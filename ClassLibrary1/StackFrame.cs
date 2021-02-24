using System.Collections.Generic;

namespace ClassLibrary1.Hide
{
    public class StackFrame
    {
        Dictionary<string, string> _variables;
        StackFrame _caller;

        public StackFrame NewFrame(Dictionary<string,string> args)
        {
            return new StackFrame(args, this);
        }

        public StackFrame Pop()
        {
            return _caller;
        }

        public StackFrame(Dictionary<string,string> _variables, StackFrame caller)
        {
            _caller = caller;
            this._variables = _variables;
        }

        public string Lookup(string key)
        {
            if (_variables.TryGetValue(key, out var result)) return result;
            else return _caller.Lookup(key);
        }
    }
}
