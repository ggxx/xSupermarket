using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.DataMining
{
    public class Apriori
    {
        private Dictionary<string, List<string>> data;
        private int minSupport;

        public Apriori(Dictionary<string, List<string>> data, int minSupport)
        {
            this.data = data;
            this.minSupport = minSupport;
        }

        public float GetSupport(List<string> items)
        {
            int sum = 0;
            ItemsKey key = new ItemsKey(items);
            foreach (KeyValuePair<string, List<string>> kvp in data)
            {
                if (key.IsIn(kvp.Value))
                {
                    sum++;
                }
            }
            return (float)sum / (float)data.Count;
        }

        public float GetConfidence(List<string> items1, List<string> items2)
        {
            int sum1 = 0;
            int sumAll = 0;
            ItemsKey key1 = new ItemsKey(items1);
            ItemsKey keyAll = new ItemsKey(items1);
            keyAll.Add(items2);

            foreach (KeyValuePair<string, List<string>> kvp in data)
            {
                if (key1.IsIn(kvp.Value))
                {
                    sum1++;
                }
                if (keyAll.IsIn(kvp.Value))
                {
                    sumAll++;
                }
            }
            return (float)sumAll / (float)sum1;
        }

        public Dictionary<List<string>, int> GetResults()
        {
            Dictionary<List<string>, int> results = new Dictionary<List<string>, int>();
            Dictionary<ItemsKey, int> dic = new Dictionary<ItemsKey, int>();

            //初始化第一次轮询
            foreach (KeyValuePair<string, List<string>> kvp in data)
            {
                foreach (string key in kvp.Value)
                {
                    ItemsKey newKey = new ItemsKey(key);
                    if (dic.ContainsKey(newKey))
                    {
                        int value;
                        if (dic.TryGetValue(newKey, out value))
                        {
                            value++;
                            dic.Remove(newKey);
                            dic.Add(newKey, value);
                        }
                    }
                    else
                    {
                        dic.Add(newKey, 1);
                    }
                }
            }

            //剪枝
            FilterDic(dic);
            List<ItemsKey> newKeys = GetNextLevelItemsKeys(dic);

            //继续轮询
            while (newKeys.Count > 0)
            {
                //先保存一遍结果
                results.Clear();
                foreach (KeyValuePair<ItemsKey, int> kvp in dic)
                {
                    results.Add(kvp.Key.Keys, kvp.Value);
                }

                dic.Clear();
                foreach (KeyValuePair<string, List<string>> kvp in data)
                {
                    foreach (ItemsKey newKey in newKeys)
                    {
                        if (newKey.IsIn(kvp.Value))
                        {
                            if (dic.ContainsKey(newKey))
                            {
                                int value;
                                if (dic.TryGetValue(newKey, out value))
                                {
                                    value++;
                                    dic.Remove(newKey);
                                    dic.Add(newKey, value);
                                }
                            }
                            else
                            {
                                dic.Add(newKey, 1);
                            }
                        }
                    }
                }

                FilterDic(dic);
                newKeys = GetNextLevelItemsKeys(dic);
            }

            return results;
        }


        /// <summary>
        /// 过滤掉小于最小支持度的项目
        /// </summary>
        /// <param name="dic"></param>
        private void FilterDic(Dictionary<ItemsKey, int> dic)
        {
            List<ItemsKey> toDeleteItems = new List<ItemsKey>();
            foreach (KeyValuePair<ItemsKey, int> kvp in dic)
            {
                if (kvp.Value < minSupport)
                {
                    toDeleteItems.Add(kvp.Key);
                }
            }
            foreach (ItemsKey key in toDeleteItems)
            {
                dic.Remove(key);
            }
        }

        /// <summary>
        /// 计算笛卡尔积，获取下一级项目列表
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        private List<ItemsKey> GetNextLevelItemsKeys(Dictionary<ItemsKey, int> keys)
        {
            List<ItemsKey> oldKeys = new List<ItemsKey>();
            foreach (KeyValuePair<ItemsKey, int> kvp in keys)
            {
                oldKeys.Add(kvp.Key);
            }

            List<ItemsKey> newKeys = new List<ItemsKey>();
            foreach (ItemsKey k1 in oldKeys)
            {
                foreach (ItemsKey k2 in oldKeys)
                {
                    if (!k1.Equals(k2))
                    {
                        ItemsKey newKey = new ItemsKey(k1.Keys);
                        newKey.Add(k2.Keys);
                        if (!newKeys.Contains(newKey))
                        {
                            newKeys.Add(newKey);
                        }
                    }
                }
            }

            SubKeys(newKeys, oldKeys);

            return newKeys;
        }

        /// <summary>
        /// 剪枝
        /// </summary>
        /// <param name="newKeys"></param>
        /// <param name="oldKeys"></param>
        private void SubKeys(List<ItemsKey> newKeys, List<ItemsKey> oldKeys)
        {
            List<ItemsKey> toDeleteList = new List<ItemsKey>();
            foreach (ItemsKey newKey in newKeys)
            {
                List<ItemsKey> newChildKeys = GetChildItemKeys(newKey);
                foreach (ItemsKey newChildKey in newChildKeys)
                {
                    if (!oldKeys.Contains(newChildKey))
                    {
                        toDeleteList.Add(newKey);
                        break;
                    }
                }
            }

            foreach (ItemsKey key in toDeleteList)
            {
                newKeys.Remove(key);
            }
        }

        /// <summary>
        /// 获取包含的子项目列表。比如输入{I1,I2,I3}，返回值为{I1,I2}{I1,I3}{I2,I3}
        /// </summary>
        /// <param name="newKey"></param>
        /// <returns></returns>
        private List<ItemsKey> GetChildItemKeys(ItemsKey key)
        {
            List<ItemsKey> list = new List<ItemsKey>();
            foreach (string item in key.Keys)
            {
                list.Add(key.SubFromClone(item));
            }
            return list;
        }


        private class ItemsKey
        {
            internal List<string> Keys { get; private set; }

            internal ItemsKey(string key)
            {
                this.Keys = new List<string>();
                this.Keys.Add(key);
            }

            internal ItemsKey(List<string> keys)
            {
                this.Keys = new List<string>();
                this.Keys.AddRange(keys);
            }

            internal void Add(string newKeys)
            {
                this.Keys.Add(newKeys);
            }

            internal void Add(List<string> newKeys)
            {
                foreach (string newKey in newKeys)
                {
                    if (!this.Keys.Contains(newKey))
                    {
                        this.Keys.Add(newKey);
                    }
                }
            }

            internal ItemsKey SubFromClone(string key)
            {
                ItemsKey newKey = new ItemsKey(this.Keys);
                newKey.Keys.Remove(key);
                return newKey;
            }

            internal bool IsIn(List<string> items)
            {
                foreach (string key in this.Keys)
                {
                    if (!items.Contains(key))
                    {
                        return false;
                    }
                }
                return true;
            }


            public override bool Equals(object obj)
            {
                if (obj is ItemsKey)
                {
                    ItemsKey k = obj as ItemsKey;
                    if (k.Keys.Count == this.Keys.Count)
                    {
                        return this.GetHashCode() == k.GetHashCode();
                    }
                }
                return false;
            }

            public override int GetHashCode()
            {
                int hashCode = 0;
                foreach (string key in Keys)
                {
                    hashCode += key.GetHashCode();
                }
                return hashCode;
            }
        }
    }
}
