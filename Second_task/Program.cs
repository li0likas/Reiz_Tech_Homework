/*
    REIZ TECH HOMEWORK ASSIGNMENT PROGRAM FOR THE .NET DEVELOPER INTERN POSITION
    2nd task
    Gvidas Garadauskas
*/

using System;
using System.Collections.Generic;

namespace Second_task
{
    /// <summary>
    /// Class of the program which is capable of printing specified tree (sub-tree)
    /// and finding its depth
    /// </summary>
    class Program
    {
        /// <summary>
        /// The first method that is invoked
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //test variant - a tree which has 5 levels
            
            Branch<string> root = new Branch<string>("root"); //an object of a tree (root) which has its sub-trees (branches)
            {
                Branch<string> branch1 = root.AddChildBranch("branch1");
                Branch<string> branch2 = root.AddChildBranch("branch2");
                Branch<string> branch3 = root.AddChildBranch("branch3");
                {
                    Branch<string> branch31 = branch3.AddChildBranch("branch31");
                    Branch<string> branch32 = branch3.AddChildBranch("branch32");
                    {
                        Branch<string> branch321 = branch32.AddChildBranch("branch321");
                        Branch<string> branch322 = branch32.AddChildBranch("branch322");
                    }
                }
                Branch<string> branch4 = root.AddChildBranch("branch4");
                {
                    Branch<string> branch41 = branch4.AddChildBranch("branch41");
                }
                Branch<string> branch5 = root.AddChildBranch("branch5");
                {
                    Branch<string> branch51 = branch5.AddChildBranch("branch51");
                    {
                        Branch<string> branch511 = branch51.AddChildBranch("branch511");
                        {
                            Branch<string> branch5111 = branch511.AddChildBranch("branch5111");
                        }
                    }
                }
            }

            root.PrintTree(root, "");
            int depth = root.CalculateDepth(root);
            Console.WriteLine("Depth of provided structure: " + depth);
        }

        /// <summary>
        /// The class of a tree (sub-tree)
        /// </summary>
        /// <typeparam name="T">type parameter</typeparam>
        class Branch<T>
        {
            List<Branch<T>> branches;

            public T value;
            public Branch<T> parent;

            /// <summary>
            /// Constructor of a tree (or its branch)
            /// </summary>
            /// <param name="data">data parameter</param>
            public Branch(T data)
            {
                this.value = data;
                this.parent = null;
                this.branches = new List<Branch<T>>();
            }

            /// <summary>
            /// Method which adds a sub-tree to tree
            /// </summary>
            /// <param name="value">data parameter</param>
            /// <returns></returns>
            public Branch<T> AddChildBranch(T value)
            {
                Branch<T> childBranch = new Branch<T>(value);
                childBranch.parent = this;
                branches.Add(childBranch);
                return childBranch;
            }

            /// <summary>
            /// Recursive Method which calculates the depth of tree (sub-tree)
            /// </summary>
            /// <param name="tree">specified tree</param>
            /// <param name="depth">integer which pluses by one after new level</param>
            /// <returns>specified tree depth</returns>
            public int CalculateDepth(Branch<T> tree, int depth = 0)
            {
                foreach (var child in tree.branches)
                {
                    CalculateDepth(child, depth++); //recursion
                }
                return depth;
            }

            /// <summary>
            /// Recursive Method which prints the tree (sub-tree) to a console
            /// </summary>
            /// <param name="tree">specified tree</param>
            /// <param name="levelString">string to help visualise tree </param>
            public void PrintTree(Branch<T> tree, string levelString)
            {
                Console.WriteLine(levelString + " " + tree.value);

                foreach (var child in tree.branches)
                {
                    PrintTree(child, levelString + "  "); //recursion
                }
            }
        }
    }
}