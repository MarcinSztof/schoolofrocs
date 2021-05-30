using System;
using System.Linq;

namespace HouseRobberIII
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public int? ConnectRobbable = null;
        public int? NotConnectRobbable = null;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
             this.Value = val;
             this.Left = left;
             this.Right = right;
        }

        public static TreeNode Create(int?[] arrayRep)
        {
            (int? Value, TreeNode Node)[] arrPaired = arrayRep.Select(x => (x, (TreeNode)null)).ToArray();
            
            var levels = Math.Log2(arrPaired.Length + 1);

            arrPaired[0].Node = new TreeNode((int)arrPaired[0].Value);
            for (int i = 0; i < levels - 1; i++)
            {
                var nodesOnLevelCount = (int)Math.Pow(2, i);
                var offset = nodesOnLevelCount - 1;
                var offsetOnNextLevel = (int)Math.Pow(2, i + 1);

                for (int j = 0; j < nodesOnLevelCount; j++)
                {
                    var currentNodeIndex = offset + j;
                    if (arrPaired[currentNodeIndex].Value == null)
                        continue;                    

                    var indexOfLeftChild = (2 * currentNodeIndex) + 1;
                    var indexOfRightChild = (2 * currentNodeIndex) + 2;

                    if(arrPaired[indexOfLeftChild].Value != null)
                    {
                        var newNode = new TreeNode(arrPaired[indexOfLeftChild].Value.Value);
                        arrPaired[indexOfLeftChild].Node = newNode;
                        arrPaired[currentNodeIndex].Node.Left = newNode;

                    }

                    if (arrPaired[indexOfRightChild].Value != null)
                    {
                        var newNode = new TreeNode(arrPaired[indexOfRightChild].Value.Value);
                        arrPaired[indexOfRightChild].Node = newNode;
                        arrPaired[currentNodeIndex].Node.Right = newNode;
                    }
                }                
            }

            return arrPaired[0].Node;
        }
    }
}
