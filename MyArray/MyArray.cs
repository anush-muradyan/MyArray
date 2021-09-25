using System;
using System.Collections;

namespace MyArray {
    class MyArray<T> : IEnumerable {
        private T[] array;
        private int pointer;
        private int Capacity;

        public int Lenght => pointer;

        public MyArray(int capacity = 5) {
            array = new T[capacity];
            pointer = 0;
            Capacity = capacity;
        }

        private void Allocate(T[] _array) {
            Capacity = 2 * pointer;
            array = new T[Capacity];
            if (_array != null) {
                for (int i = 0; i < pointer; i++) {
                    array[i] = _array[i];
                }
            }
        }

        public void Add(T value) {
            pointer++;
            if (pointer >= array.Length) {
                Allocate(array);
            }

            array[pointer - 1] = value;
        }

        public void RemoveAt(int index) {
            if (index >= array.Length || index < 0) {
                throw new IndexOutOfRangeException();
            }

            for (int i = index + 1; i < pointer; i++) {
                array[i - 1] = array[i];
            }

            --pointer;
        }


        public void Remove(T value) {
            for (int i = 0; i < pointer; i++) {
                if (array[i].Equals(value)) {
                    RemoveAt(i);
                    break;
                }
            }
        }

        public void Insert(int index, T value) {
            ++pointer;

            if (index >= array.Length || index < 0) {
                throw new IndexOutOfRangeException();
            }

            if (pointer >= Capacity) {
                Allocate(array);
            }
            else {
                for (int i = pointer - 1; i >= index; i--) {
                    array[i + 1] = array[i];
                }

                array[index] = value;
            }
        }

        public int FindIndex(T value) {
            for (int i = 0; i < array.Length; i++) {
                if (array[i].Equals(value)) {
                    return i;
                }
            }

            return -1;
        }

        public IEnumerator GetEnumerator() {
            return new MyArrayEnumerator<T>(array, pointer);
        }

        private class MyArrayEnumerator<T> : IEnumerator {
            private int i;
            private T[] array;
            private int pointer;

            public MyArrayEnumerator(T[] array, int pointer) {
                i = -1;
                this.array = array;
                this.pointer = pointer;
            }

            public bool MoveNext() {
                return i++ < pointer - 1;
            }

            public void Reset() {
                pointer = 0;
                i = -1;
            }

            public object Current => array[i];
        }

        public T this[int i] {
            get => array[i];
            set {
                if (i >= array.Length || i < 0) {
                    throw new IndexOutOfRangeException();
                }

                pointer++;
                array[i] = value;
            }
        }
    }
}