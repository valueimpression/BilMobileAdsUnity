#if UNITY_IPHONE || UNITY_IOS
using System;
using System.IO;

using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public static class PListIOSProcess
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            // Edit Info.plist
            string plistPath = Path.Combine(path, "Info.plist");
            PlistDocument plist = new PlistDocument();
            plist.ReadFromFile(plistPath);

            plist.root.SetBoolean("GADIsAdManagerApp", true);

            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}

#endif
