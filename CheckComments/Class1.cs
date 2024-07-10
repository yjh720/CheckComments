using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.IO;

namespace CheckComments
{
    public class CheckComments : Microsoft.Build.Utilities.Task
    {
        [Required]
        public ITaskItem[] Files { get; set; }

        [Required]
        public string SearchString { get; set; }

        public override bool Execute()
        {
            foreach (var file in Files)
            {
                string content = File.ReadAllText(file.ItemSpec);
                if (content.Contains(SearchString))
                {
                    Log.LogError($"The file '{file.ItemSpec}' contains '{SearchString}'. Build failed.");
                    return false;//stop building
                }
            }
            return true;// finish building
        }
    }
}
