namespace HouseRobberIII
{
    public class TreeNodeDyn
    {
        private int index;
        private int?[] array;
        public int? Value => array.Length > index ? array[index] : null;

        public TreeNodeDyn Left 
        { 
            get 
            {
                var targetIndex = (index * 2) + 1;
                return array.Length > targetIndex ?
                                (array[targetIndex] != null ? new TreeNodeDyn(array, targetIndex) : null) : null;
            }
        }

        public TreeNodeDyn Right
        {
            get
            {
                var targetIndex = (index * 2) + 2;
                return array.Length > targetIndex ?
                                (array[targetIndex] != null ? new TreeNodeDyn(array, targetIndex) : null) : null;
            }
        }

        public (int Connected, int NotConnected) Robbables
        {
            get
            {
                var left = Left;
                var right = Right;

                if (left != null && right != null)
                {
                    var leftRobbables = left.Robbables;
                    var rightRobbables = right.Robbables;

                    return ((int)Value + leftRobbables.NotConnected + rightRobbables.NotConnected,
                        leftRobbables.Connected + rightRobbables.Connected);
                }

                if (left != null || right != null)
                {
                    var singleChildRobbables = (left ?? right).Robbables;

                    return ((int)Value + singleChildRobbables.NotConnected,
                            singleChildRobbables.Connected);
                }

                // Is a leaf
                return ((int)Value, 0);
            }
        }

        public TreeNodeDyn(int?[] array, int index)
        {
            this.array = array;
            this.index = index;
        }

    }
}
