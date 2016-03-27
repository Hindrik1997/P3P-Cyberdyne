using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Resources;
using System.Windows.Forms;
using System.Collections;
using Resources;

namespace ResourceEditor
{
    public class ResourceEditor
    {
        public void Add(string path, string position, string Content)
        {
            Hashtable resourceEntries = new Hashtable();

            //Get existing resources
            ResXResourceReader reader = new ResXResourceReader(path);
            if (reader != null)
            {
                IDictionaryEnumerator id = reader.GetEnumerator();
                foreach (DictionaryEntry d in reader)
                {
                    if(d.Key.ToString() != position)
                    {
                        if (d.Value == null)
                        {
                            resourceEntries.Add(d.Key.ToString(), "");
                        }
                        else
                        {
                            resourceEntries.Add(d.Key.ToString(), d.Value.ToString());
                        }
                    }  
                }
                reader.Close();
            }

            //Write the combined resource file
            ResXResourceWriter resourceWriter = new ResXResourceWriter(path);

            foreach (String key in resourceEntries.Keys)
            {
                resourceWriter.AddResource(key, resourceEntries[key]);
            }
            resourceWriter.AddResource(position, Content);
            resourceWriter.Generate();
            resourceWriter.Close();
        }
    }
}
