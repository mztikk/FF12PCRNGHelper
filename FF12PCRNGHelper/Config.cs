using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace FF12PCRNGHelper
{
    internal static class Config
    {
        internal static int GridSize = 1000;

        internal static int RefreshInterval = 100;

        // Lags a lot on search if we set this too high, because it would create millions of random numbers to process
        // Do we even need something like 0,0,0? Rarest combination needed should be something like 0,80+,95+
        internal static int SearchDepth = 100000;

        internal static bool PatchAutoPause = false;

        //internal static int WorkerAmount = 2;

        internal static void Save(string path = "FF12PCRNGHelper.xml")
        {
            var xml = new XDocument();
            var e = new XElement("Config");
            foreach (var field in typeof(Config).GetFields(BindingFlags.Static | BindingFlags.NonPublic))
            {
                object v;
                if (field.FieldType == typeof(Color))
                {
                    v = ((Color) field.GetValue(null)).ToArgb();
                }
                else
                {
                    v = field.GetValue(null);
                }

                var attr = new XAttribute(field.Name, v);
                e.Add(attr);
            }

            xml.Add(e);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                xml.Save(stream);
            }
        }

        internal static void Load(string path = "FF12PCRNGHelper.xml")
        {
            var xml = XDocument.Load(path);
            foreach (var e in xml.Elements())
            {
                foreach (var a in e.Attributes())
                {
                    try
                    {
                        var f = typeof(Config).GetField(a.Name.LocalName, BindingFlags.Static | BindingFlags.NonPublic);
                        if (f == null)
                        {
                            continue;
                        }

                        if (f.FieldType == typeof(Color))
                        {
                            f.SetValue(null, Color.FromArgb(Convert.ToInt32(a.Value)));
                        }
                        else
                        {
                            f.SetValue(null, Convert.ChangeType(a.Value, f.FieldType));
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}