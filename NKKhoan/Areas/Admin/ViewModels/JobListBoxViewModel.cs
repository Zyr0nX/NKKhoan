﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKKhoan.Areas.Admin.ViewModels
{
    public class JobListBoxViewModel
    {
        public List<SelectListItem> jobs { set; get; }
        public int[] selectedjob { set; get; }
        public string jobName { set; get; }
    }
}