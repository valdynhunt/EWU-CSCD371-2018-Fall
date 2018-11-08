using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManager
{
    // Caveats
    // NonNullable is a reference type
    // Does not work with unmanaged types
    // If value is passed in explicitly, then we will not have value
    // equal to null, as shown in the test example with string....but we need 
    // to prevent it being set to null, as well as handle the default contructor 
    // which would not take in a value, making value equal to null, as shown in the test.
    // So how do we set a default when the type is T? Is T a string, or a chair, or 
    // a student? We are supposed to set the value for something - and we do not know 
    // what that something is. We do know that value cannot be null.
    // The way I am thinking is that it cannot have a default contructor, as we would not 
    // know how to set the value. In addition, we have to place constraints on the set
    // so that the value cannot be set to null.

    public class NonNullable<T> where T : class
    {

        public NonNullable()
        {
            HasValue = false;
        }

        public NonNullable(T value)
        {
            Value = value;
            HasValue = true;
        }

        private T _Value;
        public T Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(nameof(value), "Value cannot be set to null.");
                }

                _Value = value;
            }
        }

        //internal T value;
        //public T Value
        //{
        //  get
        //    {
        //        return value;
        //    }
        //  set
        //    {
        //        Value = value;
        //    }
        //}

        public bool HasValue { get; }

        public T GetValueOrDefault()
        {
            return Value;
        }

        public T GetValueOrDefault(T defaultValue)
        {
            return HasValue ? Value : defaultValue;
        }
    }
}
