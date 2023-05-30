using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice1.Model
{
    public class ListFriend
    {
        public string name { get; set; }
        public int age { get; set; }
        public string major { get; set; }

        public string sex { get; set; }

        public List<ListFriend> InitFriend()
        {
            var list = new List<ListFriend>();

            list.Add(new ListFriend()
            {
                name = "Ngan",
                age = 19,
                major = "accountant",
                sex = "nữ"
        });

            list.Add(new ListFriend()
            {
                name = "Minh",
                age = 22,
                major = "Hotel manager",
                sex = "nam"
            });

            list.Add(new ListFriend()
            {
                name = "Tiên",
                age = 18,
                major = "Start-up",
                sex = "nữ"
            });

            list.Add(new ListFriend()
            {
                name = "Thành",
                age = 23,
                major = "IT",
                sex = "nam"
            });

            return list;
        }
    }
}