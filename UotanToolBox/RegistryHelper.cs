using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UotanToolBox
{
    public class RegistryHelper
    {
        //读注册表数据信息
        public static object GetRegistData(string name, string patch)   //键名称
        {
            try
            {
                object registData;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey(@"Mindows", true);
                RegistryKey aimdir = software.OpenSubKey(patch, true);
                registData = aimdir.GetValue(name);
                aimdir.Close();
                return registData;
            }
            catch 
            { 
                return null;
            }
        }
        //写注册表数据信息
        public static bool WTRegedit(string name, object tovalue, string patch)
        {
            bool WriteOk = false;
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("Mindows", true);
                RegistryKey aimdir = software.CreateSubKey(patch, true);
                aimdir.SetValue(name, tovalue);
                aimdir.Close();
                WriteOk = true;
            }
            catch
            {
                WriteOk = false;
            }
            return WriteOk;
        }
        //修改注册表数据信息
        public static bool EditRegedit(string name, object tovalue, string patch)
        {
            bool EditOk = false;
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey software = hklm.OpenSubKey("Mindows", true);
            RegistryKey aimdir = software.CreateSubKey(patch);
            try
            {
                if (IsRegeditExist(name, patch))
                {
                    aimdir.SetValue(name, tovalue);
                    aimdir.Close();
                    EditOk = true;
                }
            }
            catch
            {
                aimdir.Close();
                EditOk = false;
            }
            return EditOk;
        }

        //删除注册表数据信息
        public static bool DeleteRegist(string name, string patch)
        {
            bool DeleteOk = false;
            string[] aimnames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("Mindows", true);
            RegistryKey aimdir = software.OpenSubKey(patch, true);
            aimnames = aimdir.GetValueNames();
            foreach (string aimKey in aimnames)
            {
                if (aimKey == name)
                {
                    aimdir.DeleteValue(name);
                    DeleteOk = true;
                }
            }
            aimdir.Close();
            return DeleteOk;
        }
        //判断注册表数据信息是否存在
        public static bool IsRegeditExist(string name, string patch)
        {
            bool isExist = false;
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("Mindows", true);
            RegistryKey aimdir = software.OpenSubKey(patch);
            subkeyNames = aimdir.GetValueNames();
            foreach (string keyName in subkeyNames)
            {
                if (keyName == name)
                {
                    isExist = true;
                }
            }
            aimdir.Close();
            return isExist;
        }
    }
}
