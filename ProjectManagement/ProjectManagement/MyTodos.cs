using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement
{

    public class MyTodos
    {
        public Dictionary<string,object> TodoList { get; set; }
        public Dictionary<string, object> DoneList { get; set; }

        public MyTodos()
        {
            TodoList = new Dictionary<string, object>();
            DoneList = new Dictionary<string, object>();
        }
    }
}
