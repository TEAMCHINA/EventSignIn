﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventSignIn.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BackgroundUrl { get; set; }
    }
}