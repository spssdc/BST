using System;
using System.Collections.Generic;

namespace BST
{
   class BinarySearchTree<T> where T : IComparable<T>
        {
            // Set the root attribute
            private BinaryTreeNode<T> root;

            // Define a generic node type that contains data and a left/right pointer
            internal class BinaryTreeNode<T> where T : IComparable<T>
            {
                internal T value;  // value is the data field for the node
                internal BinaryTreeNode<T> leftChild, rightChild, parent;

                public BinaryTreeNode(T item)
                {
                    if (item == null)
                    {
                        // Null values cannot be compared -> do not allow them
                        throw new ArgumentNullException("Cannot insert null value!");
                    }
                    this.value = item;
                    this.parent = null;
                    this.leftChild = null;
                    this.rightChild = null;
                }

                // Define the compare method for the object
                public int CompareTo(BinaryTreeNode<T> other)
                {
                    return this.value.CompareTo(other.value);
                }
            }

            // Default when called is to instantiate and create the root as null
            public BinarySearchTree()
            {
                this.root = null;
            }

            // Public interface of Insert() method
            public void Insert(T value)
            {
                this.root = Insert(value, null, root);
            }

            // Insert into tree method
            // Parameter 1: T value - the generic data type
            // Parameter 2: BinaryTreeNode<T> parentNode - a parent node
            // Parameter 3: BinaryTreeNode<T> node - the node
            private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    node = new BinaryTreeNode<T>(value);
                    node.parent = parentNode;
                }
                else
                {
                    int compareTo = value.CompareTo(node.value);

                    if (compareTo < 0)
                    {
                        node.leftChild = Insert(value, node, node.leftChild);
                    }
                    else if (compareTo > 0)
                    {
                        node.rightChild = Insert(value, node, node.rightChild);
                    }
                }
                return node;
            }

            // Find value in tree method; returns null if value not present
            private BinaryTreeNode<T> Find(T value)
            {
                BinaryTreeNode<T> node = this.root;

                while (node != null)
                {
                    int compareTo = value.CompareTo(node.value);

                    if (compareTo < 0)
                    {
                        node = node.leftChild;
                    }
                    else if (compareTo > 0)
                    {
                        node = node.rightChild;
                    }
                    else
                    {
                        break;
                    }
                }
                return node;
            }

            /// Value is looked for in the BST and T/F returned
            public bool Contains(T value)
            {
                bool found = this.Find(value) != null;
                return found;
            }

            public void Remove(T value)
            {
                BinaryTreeNode<T> nodeToDelete = Find(value);
                if (nodeToDelete != null)
                {
                    Remove(nodeToDelete);
                }
            }

            // Internal class definition of the Remove method
            private void Remove(BinaryTreeNode<T> node)
            {
                // Case 3: If the node has two children.
                // Note that if we get here at the end
                // the node will be with at most one child

                if (node.leftChild != null && node.rightChild != null)
                {
                    BinaryTreeNode<T> replacement = node.rightChild;

                    while (replacement.leftChild != null)
                    {
                        replacement = replacement.leftChild;
                    }
                    node.value = replacement.value;
                    node = replacement;
                }

                // Case 1 and 2: If the node has at most one child
                BinaryTreeNode<T> theChild = node.leftChild != null ?
                        node.leftChild : node.rightChild;

                // If the element to be deleted has one child
                if (theChild != null)
                {
                    theChild.parent = node.parent;

                    // Handle the case when the element is the root
                    if (node.parent == null)
                    {
                        root = theChild;
                    }
                    else
                    {
                        // Replace the element with its child sub-tree
                        if (node.parent.leftChild == node)
                        {
                            node.parent.leftChild = theChild;
                        }
                        else
                        {
                            node.parent.rightChild = theChild;
                        }
                    }
                }
                else
                {
                    // Handle the case when the element is the root
                    if (node.parent == null)
                    {
                        root = null;
                    }
                    else
                    {
                        // Remove the element - it is a leaf
                        if (node.parent.leftChild == node)
                        {
                            node.parent.leftChild = null;
                        }
                        else
                        {
                            node.parent.rightChild = null;
                        }
                    }
                }
            }

            // Public interface for Postorder traversal
            public void Postorder()
            {
                Postorder(this.root);
                Console.WriteLine();
            }

            // DFS Postorder traversal
            private void Postorder(BinaryTreeNode<T> node)
            {
                // Check children
                if (node != null)
                {
                    // Recurse left
                    Postorder(node.leftChild);
                    // Recurse right
                    Postorder(node.rightChild);
                    // Pop the item
                    Console.Write(node.value + " ");
                }
            }

            // Public interface for Breadth First traversal
            public void BreadthFirst()
            {
                BreadthFirst(this.root);
                Console.WriteLine();
            }

            private void BreadthFirst(BinaryTreeNode<T> node)
            {
                Queue<BinaryTreeNode<T>> toProcess = new Queue<BinaryTreeNode<T>>();
                BinaryTreeNode<T> currentNode;

                toProcess.Enqueue(node);
                while (toProcess.Count > 0)
                {
                    currentNode = toProcess.Dequeue();
                    Console.Write(currentNode.value + " ");
                    if (currentNode.leftChild != null)
                    {
                        toProcess.Enqueue(currentNode.leftChild);
                    }
                    if (currentNode.rightChild != null)
                    {
                        toProcess.Enqueue(currentNode.rightChild);
                    }
                }
            }

        }

    }

