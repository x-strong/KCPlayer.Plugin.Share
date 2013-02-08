namespace App.FileIO
{
    public static class Base
    {
        /// <summary>
        /// String -> Check Value -> GetBack -> String
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSafeValue(this string value)
        {
            #region String -> Check Value -> GetBack -> String

            return value.IsNullOrEmptyOrSpace() ? "" : value;

            #endregion
        }

        /// <summary>
        /// String -> Check Value -> IsNotNullOrEmpty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            #region String -> Check Value -> IsNotNullOrEmpty

            return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);

            #endregion
        }

        /// <summary>
        /// String -> Check Value -> IsNullOrEmptyOrSpace
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrSpace(this string value)
        {
            #region String -> Check Value -> IsNullOrEmptyOrSpace

            return string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value);

            #endregion
        }

        /// <summary>
        /// String -> Check Path -> IsExistFile
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsExistFile(this string path)
        {
            #region String -> Check Path -> IsExistFile

            return !path.IsNullOrEmptyOrSpace() && System.IO.File.Exists(path);

            #endregion
        }

        /// <summary>
        /// String -> Check Dir -> IsExistDir
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static bool IsExistDir(this string dir)
        {
            #region String -> Check Dir -> IsExistDir

            return !dir.IsNullOrEmptyOrSpace() && System.IO.Directory.Exists(dir);

            #endregion
        }

        /// <summary>
        /// String -> File -> ToDelete
        /// </summary>
        /// <param name="path"></param>
        public static void ToDeleteFile(this string path)
        {
            #region String -> File -> ToDelete

            if (!path.IsExistFile()) return;
            try
            {
                System.IO.File.Delete(path);
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            #endregion
        }

        /// <summary>
        /// String -> Dir -> ToDelete
        /// </summary>
        /// <param name="dir"></param>
        public static void ToDeleteDir(this string dir)
        {
            #region String -> Dir -> ToDelete

            if (!dir.IsExistDir()) return;
            try
            {
                System.IO.Directory.Delete(dir);
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            #endregion
        }

        /// <summary>
        /// String -> Dir -> ToCreatDir
        /// </summary>
        /// <param name="dir"></param>
        public static void ToCreatDir(this string dir)
        {
            #region String -> Dir -> ToCreatDir

            if (dir.IsExistDir()) return;
            try
            {
                System.IO.Directory.CreateDirectory(dir);
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            #endregion
        }

        /// <summary>
        /// String -> Path -> Ext
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToExt(this string path)
        {
            #region String -> Path -> Ext

            if (!path.IsNullOrEmptyOrSpace() && path.IsExistFile())
            {
                var ext = System.IO.Path.GetExtension(path);
                return !ext.IsNullOrEmptyOrSpace() ? ext : null;
            }
            return null;

            #endregion
        }

        /// <summary>
        /// String -> Path -> NameWithExt
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToNameWithExt(this string path)
        {
            #region String -> Path -> NameWithExt

            if (!path.IsNullOrEmptyOrSpace() && path.IsExistFile())
            {
                var name = System.IO.Path.GetFileName(path);
                return !name.IsNullOrEmptyOrSpace() ? name : null;
            }
            return null;

            #endregion
        }

        /// <summary>
        /// String -> Path -> NameNoExt
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToNameNoExt(this string path)
        {
            #region String -> Path -> ToNameNoExt

            if (!path.IsNullOrEmptyOrSpace() && path.IsExistFile())
            {
                var name = System.IO.Path.GetFileNameWithoutExtension(path);
                return !name.IsNullOrEmptyOrSpace() ? name : null;
            }
            return null;

            #endregion
        }

        /// <summary>
        /// List -> IsEmptyList
        /// </summary>
        /// <param name="iList"></param>
        /// <returns></returns>
        public static bool IsEmptyList(this System.Collections.Generic.List<string> iList)
        {
            #region List -> IsEmptyList

            return iList == null || iList.Count <= 0;

            #endregion
        }

        /// <summary>
        /// String[] -> IsEmptyStrings
        /// </summary>
        /// <param name="iString"></param>
        /// <returns></returns>
        public static bool IsEmptyStrings(this string[] iString)
        {
            #region String[] -> IsEmptyStrings

            return iString == null || iString.Length <= 0;

            #endregion
        }

        /// <summary>
        /// Byte[] -> IsEmptyBytes
        /// </summary>
        /// <param name="iBytes"></param>
        /// <returns></returns>
        public static bool IsEmptyBytes(this byte[] iBytes)
        {
            #region Byte[] -> IsEmptyBytes

            return iBytes == null || iBytes.Length <= 0;

            #endregion
        }

        /// <summary>
        /// Image -> IsEmptyImage
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static bool IsEmptyImage(this System.Drawing.Image image)
        {
            #region Image -> IsEmptyImage

            return image == null;

            #endregion
        }

        /// <summary>
        /// object -> IsEmpty
        /// </summary>
        /// <param name="iO"></param>
        /// <returns></returns>
        public static bool IsEmpty(this object iO)
        {
            #region object -> IsEmpty

            return iO == null;

            #endregion
        }

        /// <summary>
        /// Thread -> IsLive
        /// </summary>
        /// <param name="iThread"></param>
        /// <returns></returns>
        public static bool IsLive(this System.Threading.Thread iThread)
        {
            #region Thread -> IsLive

            return iThread != null && iThread.IsAlive;

            #endregion
        }

        /// <summary>
        /// String -> OpenWebLink
        /// </summary>
        /// <param name="s"></param>
        public static void OpenWebLink(this string s)
        {
            #region String -> OpenWebLink

            if (s.IsNullOrEmptyOrSpace()) return;
            if (!s.StartsWith("http://") && s.StartsWith("www."))
            {
                s = "http://" + s;
            }
            try
            {
                System.Diagnostics.Process.Start(s);
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            #endregion
        }

        /// <summary>
        /// String -> OpenLocalPath
        /// </summary>
        /// <param name="s"></param>
        public static void OpenLocalPath(this string s)
        {
            #region String -> OpenLocalPath

            if (s.IsNullOrEmptyOrSpace()) return;
            try
            {
                System.Diagnostics.Process.Start(s);
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            #endregion
        }

        /// <summary>
        /// String -> LocalPath -> PickMe
        /// </summary>
        /// <param name="s"></param>
        public static void PickMe(this string s)
        {
            #region String -> LocalPath -> PickMe

            if (s.IsNullOrEmptyOrSpace()) return;
            try
            {
                System.Diagnostics.Process.Start("Explorer.exe", "/select," + s);
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            #endregion
        }

    }


}