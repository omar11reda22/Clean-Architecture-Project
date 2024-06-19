using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Services
{//
    // https://github.com/omar11reda22/Clean-Architecture-Project
    public class FileStorageService : IFileStorageService
    {
        private readonly string webrootpath;


        public FileStorageService(string webrootpath)
        {
           this.webrootpath = webrootpath;
        }

        public async Task<string> SaveFileAsync(Stream fileStreamm, string fileName)
        {
            // get file name 
            var filename = Path.GetFileName(fileName);

           // define the path to save to wwwroot [but wwwroot not here in this layer] 
            var uploadPath = Path.Combine(webrootpath, "Uploads");
            //ensure the directory exists 
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            // path file saving [This is a string variable holding the path to the file where you want to write data.]
            var filePath = Path.Combine(uploadPath, filename);
            // filemode.create : This specifies that if the file already exists, it should be overwritten. If the file does not exist, it will be created.
            using (var fileStreamoutput = new FileStream(filePath, FileMode.Create))
            {
                await fileStreamm.CopyToAsync(fileStreamoutput);
              // await fileStreamoutput.CopyToAsync(fileStreamm);  
            }

            return filePath;
        }
    }
}
