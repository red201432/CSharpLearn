using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForToArray
{
    class Tree<TItem> where TItem:IComparable<TItem>
    {
        public TItem NodeData { get; set; }
        public Tree<TItem> LeftTree { get; set; }
        public Tree<TItem> RightTree { get; set; }

        public Tree(TItem nodeValue) 
        {
            this.NodeData = nodeValue;
            this.LeftTree = null;
            this.RightTree = null;
        }
        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="newItem"></param>
        public void insert(TItem newItem)
        {
            TItem currentNodeValue = this.NodeData;
            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                //插入左子树
                if (this.LeftTree == null)
                {
                    this.LeftTree = new Tree<TItem>(newItem);
                }
                else
                {
                    this.LeftTree.insert(newItem);
                }
            }
            else
            {
                //插入右子树
                if (this.RightTree == null)
                {
                    this.RightTree = new Tree<TItem>(newItem);
                }
                else
                {
                    this.RightTree.insert(newItem);
                }
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="item"></param>
         public static int i = 0;
        public void delete(TItem item)
        {
            i++;
            TItem currentItem = this.NodeData;
            if (currentItem.CompareTo(item) == 0)
            {
                //如果这个节点需要删除，那么需要对这个节点进行判断：
                //1 这个节点没有子节点
                //2 这个节点只有一层节点
                //3 这个节点的子节点还有节点
                if (this.RightTree == null && this.LeftTree == null)
                {
                    ;
                }
                Console.WriteLine("AAAAAAAAA"+i);
            }
            else if (currentItem.CompareTo(item) > 0)
            {
                this.LeftTree.delete(item);
            }
            else
            {
                this.RightTree.delete(item);
            }
            
        }

        /// <summary>
        /// 遍历并输出
        /// </summary>
        public void walkTree()
        {
            if (this.LeftTree != null)
            {
                this.LeftTree.walkTree();
            }
            Console.WriteLine(this.NodeData.ToString());
            if (this.RightTree != null)
            {
                this.RightTree.walkTree();
            }
        }
    }
}
