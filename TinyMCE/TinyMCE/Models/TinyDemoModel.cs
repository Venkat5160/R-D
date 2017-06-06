using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyMCE.Models
{
    public class TinyDemoModel
    {
        public int Id { get; set; }
        [UIHint("tinymce_jquery_full")]
        [AllowHtml]
        public string Template { get; set; }
    }
}