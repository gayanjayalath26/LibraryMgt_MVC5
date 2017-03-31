using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.Libarary
{
    public class Lend
    {
        public int LendID { get; set; }

        public int Book_CopyID { get; set; }

        public int MemberID { get; set; }

        public Book_Copy Book_Copy { get; set; }

        public Member Member { get; set; }

        public DateTime LendingDate { get; set; }

        public DateTime ExpiredDate { get; set; }
    }
}