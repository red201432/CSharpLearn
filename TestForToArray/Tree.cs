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
