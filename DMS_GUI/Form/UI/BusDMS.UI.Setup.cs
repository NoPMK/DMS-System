namespace DMS_GUI
{
    public partial class BusDMS
    {
        // Setup and Initialization
        private void PopulateStructureTree(TreeView treeView, string drivePath)
        {
            var driveInfo = _setupService.GetDrive(drivePath);
            if (driveInfo == null)
            {
                return;
            }

            var driveNode = AddDriveNodes(treeView, driveInfo);
            driveNode.Expand();

            AddInitialDirectories(drivePath, driveInfo, driveNode);
        }

        private void AddInitialDirectories(string drivePath, DriveInfo drive, TreeNode driveNode)
        {
            if (drive.IsReady)
            {
                var nodeDTOs = _setupService.GetTreeNodes(drivePath);
                foreach (var nodeDTO in nodeDTOs)
                {
                    var node = _controlItemConverter.ConvertToTreeNode(nodeDTO);
                    driveNode.Nodes.Add(node);
                }
            }
            else
            {
                driveNode.Nodes.Add("dummy");
            }
        }

        private static TreeNode AddDriveNodes(TreeView treeView, DriveInfo drive)
        {
            var driveNode = new TreeNode()
            {
                Text = $"{drive.Name}",
                Tag = drive.Name
            };

            treeView.Nodes.Add(driveNode);
            return driveNode;
        }

        private void PopulateDriveComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            var drives = _setupService.GetReadyDrives();
            foreach (var drive in drives)
            {
                comboBox.Items.Add(drive.Name);
            }
        }
    }
}