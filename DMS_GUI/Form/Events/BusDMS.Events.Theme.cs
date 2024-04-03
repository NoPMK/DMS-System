using DMS_GUI.NativeMethod;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // ThemeSwitcher
        private void ThemeSwitcher_ValueChanged(object sender, EventArgs e)
        {
            switch (ThemeSwitcher.Value)
            {
                case 0:
                    SwitchToDarkTheme();
                    break;
                case 1:
                    SwitchToLightTheme();
                    break;
            }
        }

        private void SwitchToLightTheme()
        {
            State.IsThemeDark = false;

            SetLeftPanelToLight();

            SetMiddlePanelToLight();

            SetMenuStripToLight();

            SetRightPanelToLight();

            SetOutputWindowToLight();
        }

        private void SwitchToDarkTheme()
        {
            State.IsThemeDark = true;

            SetLeftPanelToDark();

            SetMiddlePanelToDark();

            SetMenuStripToDark();

            SetRightPanelToDark();

            SetOutputWindowToDark();
        }

        private void SetExplorerTheme()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ListView || ctrl is TreeView)
                {
                    NativeMethods.SetWindowTheme(ctrl.Handle, "explorer", null);
                }
                // Recursively apply the theme to controls in containers.
                SetExplorerThemeRecursive(ctrl.Controls);
            }
        }

        private void SetExplorerThemeRecursive(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is ListView || ctrl is TreeView)
                {
                    NativeMethods.SetWindowTheme(ctrl.Handle, "explorer", null);
                }
                if (ctrl.HasChildren)
                {
                    SetExplorerThemeRecursive(ctrl.Controls);
                }
            }
        }
    }
}