using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geeeldime_Geeeldim
{
    [Serializable]
    class GenericStore<T> :IEnumerable<T>
        where T : class
    {
        T[] data = new T[0];


        public void Add(T entity)
        {
            //3+1=4  3
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = entity;
        }


        public void RemoveAt(int index)
        {
            if (index < 0 || index >= data.Length)
                return;


            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }

            Array.Resize(ref data, data.Length - 1);
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(data, item);

            RemoveAt(index);
        }

        public bool Exists(Func<T, bool> predicate)
        {
            bool hasEntity = data.Any(predicate);
            return hasEntity;
        }

        public T Find(Func<T, bool> predicate)
        {
            T current = data.FirstOrDefault(predicate);
            return current;
        }

        public T[] FindAll(Func<T, bool> predicate)
        {
            T[] current = data.Where(predicate).ToArray();
            return current;
        }


        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= data.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return data[index];
            }
        }


        public int Count
        {
            get
            {
                return data.Length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //var unboxing = (IEnumerable)this;
            //var unboxing = this as IEnumerable;

            //if (unboxing != null)
            //{

            //}

            return GetEnumerator();
        }
    }
}
