using System;

namespace HouseRobberIII
{
    public class Solution
    {
        public static int Rob(TreeNode root)
        {
            CalculateRobbables(root);
            return Math.Max((int)root.NotConnectRobbable, (int)root.ConnectRobbable);
        }

        private static void CalculateRobbables(TreeNode node)
        {
            if (node.Left == null && node.Right == null)
            {
                node.ConnectRobbable = node.Value;
                node.NotConnectRobbable = 0;
                return;
            }
            
            if (node.Left == null || node.Right == null)
            {
                var singleChild = node.Left ?? node.Right;
                CalculateRobbables(singleChild);
                node.ConnectRobbable = node.Value + singleChild.NotConnectRobbable;
                node.NotConnectRobbable = singleChild.ConnectRobbable;
                return;
            }

            CalculateRobbables(node.Left);
            CalculateRobbables(node.Right);

            node.ConnectRobbable = node.Value + node.Left.NotConnectRobbable + node.Right.NotConnectRobbable;

            node.NotConnectRobbable = node.Left.ConnectRobbable + node.Right.ConnectRobbable;
        }

        public static int Rob(TreeNodeDyn root)
        {
            var robbables = root.Robbables;
            return Math.Max(robbables.Connected, robbables.NotConnected);
        }
    }
}
