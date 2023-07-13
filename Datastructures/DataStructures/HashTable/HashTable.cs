using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.DataStructures
{
    public class HashTable
    {
        private class KeyValuePair
        {
            public int _key;
            public string _value;
            public KeyValuePair(int key, string value)
            {
                _key = key;
                _value = value;
            }
        }

        LinkedList<KeyValuePair>[] list = new LinkedList<KeyValuePair>[5];

        public void Put(int key,string value)
        {
            var entry = GetEntry(key);
            if(entry != null)
            {
                entry._value = value;
                return;
            }
            //var bucket = GetOrUpdateBucket(key);
            GetOrUpdateBucket(key).AddLast(new KeyValuePair(key, value));
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);
            return (entry == null) ? null : entry._value;
            //before refactoring
            //var index = HashFunction(key);
            //var bucket = list[index];

            //if (bucket != null)
            //{
            //    foreach (var data in bucket)
            //    {
            //        if (data._key == key)
            //            return data._value;
            //        return null;
            //    }
            //}
            
            //return null;
        }

        public void Remove(int key)
        {
            var entry = GetEntry(key);
            if(entry == null)
                throw new InvalidOperationException();
            GetBucket(key).Remove(entry);
            //before refactoring
            //var index = HashFunction(key);
            //var bucket = list[index];
            //if (bucket == null)
            //    throw new InvalidOperationException();

            //foreach(var data in bucket)
            //{
            //    if (data._key == key)
            //    {
            //        bucket.Remove(data);
            //        return;
            //    }
            //}

            //throw new InvalidOperationException();
        }
        private int HashFunction(int key)
        {
            return key % list.Length;
        }

        private LinkedList<KeyValuePair> GetOrUpdateBucket(int key)
        {
            var index = HashFunction(key);
            if (list[index] == null)
                list[index] = new LinkedList<KeyValuePair>();

            return list[index];
        }
        private LinkedList<KeyValuePair> GetBucket(int key)
        {
            return list[HashFunction(key)];
        }
        private KeyValuePair GetEntry(int key)
        {
            var bucket = GetBucket(key);

            if(bucket != null)
            {
                foreach(var data in bucket)
                {
                    if (data._key == key)
                        return data;
                }
            }
            return null;
        }
    }
}
