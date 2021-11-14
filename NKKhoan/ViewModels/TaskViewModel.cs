using NKKhoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKKhoan.ViewModels
{
    public class TaskViewModel
    {
        public IEnumerable<NKSLK> NKSLKs { get; set; }
        public IEnumerable<CongNhan> CongNhans { get; set; }
        public IEnumerable<CongViec> CongViecs { get; set; }
    }
}