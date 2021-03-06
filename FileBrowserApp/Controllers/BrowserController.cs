﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileBrowserApp.Models;
using System.IO;
using System.Diagnostics;

namespace FileBrowserApp.Controllers
{
    public class BrowserController : ApiController
    {
        // GET api/values
        public string Get()
        {
            return Explorer.GetAllInFolder(@"Computer");
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string path)
        {
            string result = null;
            if (!Explorer.IsDirectory(path))
            {
                Explorer.OpenFile(path);
                FileInfo info = new FileInfo(path);
                path = info.Directory.FullName;
            }
            result = Explorer.GetAllInFolder(path);
            return result;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
