﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNews.Models
{
    public class ArticleModel
    {
        public string SectionName { get; set; }
        public DateTime WebPublicationDate { get; set; }

        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
    }
}
