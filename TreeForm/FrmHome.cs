using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeForm.models;

namespace TreeForm
{
    public partial class FrmHome : Form
    {
        private TreeView treeview;
        private TreeView treeview2;
        private Button showCheckedNodesButton;
        private TreeViewCancelEventHandler checkForCheckedChildren;

        public FrmHome()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(818, 497);

            this.treeview = new TreeView();
            this.Controls.Add(treeview);
            this.treeview.Location = new Point(88, 95);
            this.treeview.Size = new Size(248, 316);
            this.populateTree();

            this.treeview2 = new TreeView();
            this.Controls.Add(treeview2);
            this.treeview2.Location = new Point(430, 95);
            this.treeview2.Size = new Size(248, 316);
            this.treeview2.CheckBoxes = true;

            TreeNode node;
            for (int x = 0; x < 3; ++x)
            {
                // Add a root node.
                node = this.treeview2.Nodes.Add(String.Format("Node{0}", x*4));
                for (int y = 1; y < 4; ++y)
                {
                    // Add a node as a child of the previously added node.
                    node = node.Nodes.Add(String.Format("Node{0}", x*4 + y));
                }
            }

            this.treeview2.Nodes[1].Nodes[0].Nodes[0].Checked = true;

           

            this.showCheckedNodesButton = new Button();
            this.checkForCheckedChildren = new TreeViewCancelEventHandler(CheckForCheckedChildrenHandler);

            this.showCheckedNodesButton=new Button();
            this.Controls.Add(showCheckedNodesButton);
            this.showCheckedNodesButton.Size = new Size(144, 24);
            this.showCheckedNodesButton.Text = "Show Checked Nodes";
            this.showCheckedNodesButton.Click += new EventHandler(showCheckedNodesButton_Click);


        }

        private void showCheckedNodesButton_Click(object sender, EventArgs e)
        {
            // Disable redrawing of treeView1 to prevent flickering 
            // while changes are made.
            this.treeview2.BeginUpdate();

            // Collapse all nodes of treeView1.
            this.treeview2.ExpandAll();

            // Add the checkForCheckedChildren event handler to the BeforeExpand event.
            this.treeview2.BeforeCollapse += checkForCheckedChildren;

            // Expand all nodes of treeView1. Nodes without checked children are 
            // prevented from expanding by the checkForCheckedChildren event handler.
            this.treeview2.CollapseAll();

            // Remove the checkForCheckedChildren event handler from the BeforeExpand 
            // event so manual node expansion will work correctly.
            this.treeview2.BeforeCollapse -= checkForCheckedChildren;

            // Enable redrawing of treeView1.
            this.treeview2.EndUpdate();
        }

        private bool HasCheckedChildNodes(TreeNode node)
        {
            if (node.Nodes.Count == 0) return false;
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Checked) return true;
                // Recursively check the children of the current child node.
                if (HasCheckedChildNodes(childNode)) return true;
            }
            return false;
        }

        private void CheckForCheckedChildrenHandler(object sender, TreeViewCancelEventArgs e)
        {
            if (HasCheckedChildNodes(e.Node)) e.Cancel = true;
        }

        public void populateTree()
        {

            Persoana p1 = new Persoana("deputy director", 45, "parola1", 0);
            Persoana p2 = new Persoana("it division", 29, "parola2", 1);
            Persoana p3 = new Persoana("marketing", 23, "parola3", 1);
            Persoana p4 = new Persoana("security", 42, "parola4", 1);
            Persoana p5 = new Persoana("app development", 42, "parola5", 1);
            Persoana p6 = new Persoana("logistics", 42, "parola6", 1);
            Persoana p7 = new Persoana("public relations", 42, "parola7", 1);

            List<Persoana> lista = new List<Persoana>();

            lista.AddRange(new Persoana[] { p1, p2, p3, p4, p5, p6,p7 });

            this.treeview.BeginUpdate();
            this.treeview.Nodes.Add(p1.Nume);
            this.treeview.Nodes[0].Nodes.Add(new TreeNode(p2.Nume));
            this.treeview.Nodes[0].Nodes.Add(new TreeNode(p3.Nume));
            this.treeview.Nodes[0].Nodes[0].Nodes.Add(new TreeNode(p4.Nume));
            this.treeview.Nodes[0].Nodes[0].Nodes.Add(new TreeNode(p5.Nume));
            this.treeview.Nodes[0].Nodes[1].Nodes.Add(new TreeNode(p6.Nume));
            this.treeview.Nodes[0].Nodes[1].Nodes.Add(new TreeNode(p7.Nume));
            this.treeview.EndUpdate();

        }
        

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
