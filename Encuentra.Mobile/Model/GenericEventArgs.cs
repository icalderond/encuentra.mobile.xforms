using System;
namespace Encuentra.Mobile.Model
{
    public class GenericEventArgs<T> : EventArgs
    {
        public T Result;
        public GenericEventArgs(T _result)
        {
            Result = _result;
        }
    }
}