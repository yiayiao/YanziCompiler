using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.SyntacticAnalyzer;

namespace Algorithm.SyntacticAnalyzer
{
    public class ItemFamily
    {
        public ProductionManager Grammer { get; private set; }
        public List<ItemSet> AllItemSet { get; private set; }
        public ItemSet FirstItemSet { get; set; }

        public ItemFamily(ProductionManager grammer)
        {
            AllItemSet = new List<ItemSet>();
            this.Grammer = grammer;
        }

        /// <summary>
        /// 将新的项目加入ItemFamily中，注意将进行闭包处理
        /// </summary>
        /// <param name="newItem"></param>
        public void Register(ItemSet newItem)
        {
            this.AllItemSet.Add(newItem);
            newItem.SetFamily(this);
            newItem.CalcClosure();
        }

        public int CombineSameCoreItems()
        {
            int count = 0;
            HashSet<ItemSet> removedSet = new HashSet<ItemSet>();

            var result = from i1 in AllItemSet
                         join i2 in AllItemSet
                         on true equals true
                         where i1.IsSameCoreWith(i2)
                         && i1 != i2
                         group i2 by i1 into rg
                         select new
                         {
                             ItemSet = rg.Key,
                             SameCoreItemSets = rg
                         };
            foreach (var record in result)
            {
                if (removedSet.Contains(record.ItemSet))
                    continue;
                foreach (ItemSet toCombine in record.SameCoreItemSets)
                {
                    record.ItemSet.CombineBySameCore(toCombine);
                    removedSet.Add(toCombine);
                }
                count++;
            }

            AllItemSet.RemoveAll(c => removedSet.Contains(c));
            return count;
        }

    
    }
}
