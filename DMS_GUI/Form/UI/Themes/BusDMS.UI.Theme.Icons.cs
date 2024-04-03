using DMS_GUI.NativeMethod;
using System.Runtime.InteropServices;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        private void AddItemWithSystemIcon(ListViewItem item, ListView listView)
        {
            Icon smallIcon;
            Icon largeIcon;

            var itemPath = item.Tag.ToString();
            var cacheKey = GetCacheKey(itemPath, listView);

            var extensionKey = Path.GetExtension(itemPath).ToLowerInvariant();
            if (!string.IsNullOrEmpty(extensionKey) && !State.IconCache.TryGetValue(extensionKey, out _))
            {
                cacheKey = extensionKey;
            }

            if (!State.IconCache.TryGetValue(cacheKey, out int iconIndex))
            {
                smallIcon = GetIcon(itemPath, true);
                largeIcon = GetIcon(itemPath, false);

                if (smallIcon != null)
                {
                    SetIcons(listView, smallIcon, largeIcon, cacheKey);
                }
                else
                {
                    GetDefaultIcons(listView, smallIcon, largeIcon, cacheKey, iconIndex);
                }
            }

            item.ImageIndex = State.IconCache[cacheKey];
        }

        private int SetIcons(ListView listView, Icon smallIcon, Icon largeIcon, string cacheKey)
        {
            var iconIndex = listView.SmallImageList.Images.Count;
            listView.SmallImageList.Images.Add(smallIcon);
            listView.LargeImageList.Images.Add(largeIcon);
            State.IconCache[cacheKey] = iconIndex;
            return iconIndex;
        }

        private void GetDefaultIcons(ListView listView, Icon smallIcon, Icon largeIcon, string cacheKey, int iconIndex)
        {
            smallIcon = GetDefaultIcon();
            largeIcon = GetDefaultIcon();
            iconIndex = listView.SmallImageList.Images.Count;
            listView.SmallImageList.Images.Add(smallIcon);
            listView.LargeImageList.Images.Add(largeIcon);
            State.IconCache[cacheKey] = iconIndex;
        }

        private Icon GetIcon(string itemPath, bool small)
        {
            NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();
            var flags = NativeMethods.SHGFI_ICON | (small ? NativeMethods.SHGFI_SMALLICON : NativeMethods.SHGFI_LARGEICON);
            NativeMethods.SHGetFileInfo(itemPath, 0, ref shfi, (uint)Marshal.SizeOf(shfi), flags);

            if (shfi.hIcon != IntPtr.Zero)
            {
                return Icon.FromHandle(shfi.hIcon);
            }
            else
            {
                return GetDefaultIcon();
            }
        }

        private Icon GetDefaultIcon()
        {
            const string defaultKey = "defaultIcon";
            if (!State.IconCache.TryGetValue(defaultKey, out int iconIndex))
            {
                var defaultIcon = (Icon)SystemIcons.Application.Clone();
                iconIndex = State.ActiveListView.SmallImageList.Images.Count;
                State.ActiveListView.SmallImageList.Images.Add(defaultIcon.ToBitmap());
                State.ActiveListView.LargeImageList.Images.Add(defaultIcon.ToBitmap());
                State.IconCache[defaultKey] = iconIndex;
            }

            return ConvertImageToIcon(State.ActiveListView.SmallImageList.Images[State.IconCache[defaultKey]]);
        }

        private Icon ConvertImageToIcon(Image image)
        {
            using (var bitmap = new Bitmap(image))
            {
                return Icon.FromHandle(bitmap.GetHicon());
            }
        }

        private string GetCacheKey(string itemPath, ListView listView)
        {
            string identifier = listView == LeftList ? "left" : "right";
            string key = itemPath;
            return $"{identifier}:{key}";
        }
    }
}