using System;
using System.Collections;

namespace MyArray {
    
    public class KeyValue<TKey, TValue> {
        public TKey Key { get; }
        public TValue Value { get; }

        public KeyValue(TKey key, TValue value) {
            Key = key;
            Value = value;
        }

        public override string ToString() {
            return $"{Key}:{Value}";
        }
    }
    
    public class Map<TKey, TValue> {
        private TKey[] keyArray;
        private TValue[] valueArray;
        private int pointer;
        private int capacity;

        public Map(int capacity = 5) {
            this.capacity = capacity;
            keyArray = new TKey[capacity];
            valueArray = new TValue[capacity];
            pointer = 0;
        }

        private void allocate(TKey[] _array1, TValue[] _array2) {
            capacity = 2 * pointer;
            keyArray = new TKey[capacity];
            valueArray = new TValue[capacity];
            if (_array1 == null) {
                return;
            }

            for (int i = 0; i < pointer; i++) {
                keyArray[i] = _array1[i];
                valueArray[i] = _array2[i];
            }
        }
        
        public void Add(TKey value, TValue cnt) {
            ++pointer;
            if (pointer >= keyArray.Length) {
                allocate(keyArray, valueArray);
            }

            for (int i = 0; i < pointer; i++) {
                if (keyArray[i] != null && keyArray[i].Equals(value)) {
                    throw new Exception();
                }
            }

            keyArray[pointer - 1] = value;
            valueArray[pointer - 1] = cnt;
        }
        
        public void Remove(TKey str) {
            bool flag = false;
            for (int i = 0; i < pointer; i++) {
                if (keyArray[i].Equals(str)) {
                    RemoveAt(i);
                    flag = true;
                    break;
                }
            }

            if (!flag) {
                throw new Exception();
            }
        }

        public void RemoveAt(int index) {
            if (index >= keyArray.Length || index < 0) {
                throw new IndexOutOfRangeException();
            }

            for (int i = index + 1; i < pointer; i++) {
                keyArray[i - 1] = keyArray[i];
                valueArray[i - 1] = valueArray[i];
            }

            --pointer;
        }

        public IEnumerator GetEnumerator() {
            return new MyEnumarator<TKey, TValue>(keyArray, valueArray, pointer);
        }

        private class MyEnumarator<TKey, TValue> : IEnumerator {
            private TKey[] keyArray;
            private TValue[] valueArray;
            private int i;
            private int _pointer;

            public MyEnumarator(TKey[] _keyArray, TValue[] _valueArray, int pointer) {
                keyArray = _keyArray;
                valueArray = _valueArray;
                i = -1;
                _pointer = pointer;
            }

            public bool MoveNext() {
                if (i++ < _pointer - 1) {
                    return true;
                }

                return false;
            }

            public void Reset() {
                _pointer = 0;
                i = -1;
            }

            public object Current => new KeyValue<TKey, TValue>(keyArray[i], valueArray[i]);
        }
    }
}