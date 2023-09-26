using System.ComponentModel;

namespace DiscreteMathCursovaya.Modules._2_Module.models
{
    class TaskItem
    {
        public string TaskText { get; private set; }
        public string Answer { get; set; }

        public TaskItem(string taskText)
        {
            TaskText = taskText;
            Answer = "";
        }
    }
}
