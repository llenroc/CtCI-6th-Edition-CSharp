using System;
using System.Collections.Generic;
using System.Text;

namespace ctci.Library
{
    public static class XTreePrinter
    {
        public static void Print(this TreeNode root, int topMargin = 2, int leftMargin = 2)
        {
            var height = root.Height();
            var maxWidth = (1 << (height - 1)) * 4;
            var sb = new StringBuilder();
            var currentList = new List<TreeNode>() { root };
            var loop = true;
            var currentDepth = 1;
            while (loop)
            {
                var prevList = currentList;
                currentList = new List<TreeNode>();
                var firstChar = true;
                var gap = maxWidth / (1 << currentDepth);
                foreach (var item in prevList)
                {
                    currentList.Add(item?.Left);
                    currentList.Add(item?.Right);

                    if (firstChar)
                    {
                        if (gap - 1 > 0 && currentDepth != height)
                            sb.Append('.', gap - 1);
                        firstChar = false;
                    }
                    else
                    {
                        sb.Append('.', gap * 2 - 1);
                    }
                    if (item != null) sb.Append($"{item.Data:000}");
                    else sb.Append("   ");
                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
                loop = false;
                gap = maxWidth / (1 << (currentDepth + 1));
                foreach (var item in prevList)
                {
                    if (gap - 1 > 0)
                        sb.Append('.', gap - 1);
                    if (item?.Left != null)
                    {
                        sb.Append('┌');
                        sb.Append('─', gap / 2);
                        sb.Append('┘');
                        loop = true;
                    }
                    else
                    {
                        sb.Append(' ');
                        sb.Append(' ', gap / 2);
                        sb.Append(' ');
                    }
                    sb.Append(' ');
                    if (item?.Right != null)
                    {
                        sb.Append('└');
                        sb.Append('─', gap / 2);
                        sb.Append('┐');
                        loop = true;
                    }
                    else
                    {
                        sb.Append(' ');
                        sb.Append(' ', gap / 2);
                        sb.Append(' ');
                    }
                    currentDepth++;
                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
        }

    }
}