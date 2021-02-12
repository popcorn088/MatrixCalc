using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace MCTool
{
    public class DLLInfo
    {
        public string classname;
        public string fullpath;
        public IButton ibutton;

        public DLLInfo() { }
        public DLLInfo(string dllpath)
        {
            string ipluginName = typeof(IButton).FullName;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(dllpath);
                foreach (Type t in asm.GetTypes())
                {
                    if (t.IsClass && t.IsPublic && !t.IsAbstract && t.GetInterface(ipluginName) != null)
                    {
                        classname = t.FullName;
                        fullpath = dllpath;
                        ibutton = (IButton)asm.CreateInstance(classname);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception();
            }
        }

        public static List<DLLInfo> GetDLLInfo(string dllpath)
        {
            List<DLLInfo> ret = new List<DLLInfo>();

            string ipluginName = typeof(IButton).FullName;
            try
            {

                System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(dllpath);
                foreach (Type t in asm.GetTypes())
                {
                    if (t.IsClass && t.IsPublic && !t.IsAbstract && t.GetInterface(ipluginName) != null)
                    {
                        DLLInfo tmp = new DLLInfo();
                        tmp.classname = t.FullName;
                        tmp.fullpath = dllpath;
                        tmp.ibutton = null;

                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception();
            }

            return ret;
        }

        public IButton CreateInstance()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(fullpath);
            ibutton = (IButton)asm.CreateInstance(classname);

            return ibutton;
        }
    }
}
