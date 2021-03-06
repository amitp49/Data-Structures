﻿using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class AugmentedBst<T> : BinarySearchTree<T> where T: IComparable
    {
        public AugmentedBst()
        {

        }

        public AugmentedBst(BinaryTreeNode<T> root)
            : base(root)
        {

        }

        public override BinaryTreeNode<T> Insert(T newData)
        {
            return base.Insert(newData);
        }

        public override BinaryTreeNode<T> Insert(BinaryTreeNode<T> newNode)
        {
            return base.Insert(newNode);
        }
        public override void BranchingToRightAddOnHook(BinaryTreeNode<T> currentRoot, BinaryTreeNode<T> newNode)
        {
            //Allow child classes to do extra logic if they want on right branching
            if (currentRoot.AddOns == null)
            {
                currentRoot.AddOns = new DataList(2);
                currentRoot.AddOns[1] = 1;

            }
            else
            {
                currentRoot.AddOns[1] += 1;
            }
        }

        public override void BranchingToLeftAddOnHook(BinaryTreeNode<T> currentRoot, BinaryTreeNode<T> newNode)
        {
            //Allow child classes to do extra logic if they want on left branching
            if (currentRoot.AddOns == null)
            {
                currentRoot.AddOns = new DataList(2);
                currentRoot.AddOns[0] = 1;

            }
            else
            {
                currentRoot.AddOns[0] += 1;
            }
        }

        public BinaryTreeNode<T> KthSmallestNodeInOrderOfHeightTime(int k)
        {
            return KthSmallestNodeInOrderOfHeightTimeInternalUtil(this.Root, k);
        }

        private BinaryTreeNode<T> KthSmallestNodeInOrderOfHeightTimeInternalUtil(BinaryTreeNode<T> currentRoot, int k)
        {
            if (currentRoot == null)
                return null;

            //Inorder processing
            if ( (currentRoot.AddOns!=null && currentRoot.AddOns[0] == k-1) ||
                (k==1))
            {
                return currentRoot;
            }
            else if ( (currentRoot.AddOns != null &&  currentRoot.AddOns[0] > k - 1) ||
                (1 > k))
            {
                return KthSmallestNodeInOrderOfHeightTimeInternalUtil(currentRoot.Left, k);
            }
            else if ( (currentRoot.AddOns != null &&  currentRoot.AddOns[0] < k - 1) ||
            (1< k))
            {
                return KthSmallestNodeInOrderOfHeightTimeInternalUtil(currentRoot.Right, k - (currentRoot.AddOns[0] + 1)); //left subtree + root counted
            }

            return null;
        }
    }
}
