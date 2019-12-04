using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using AppContext = RespositorioREPIS.Data.AppContext;

namespace RespositorioREPIS.Api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        
        private readonly AppContext appContext;

        public TestController(AppContext appContext)
        {
            this.appContext = appContext;
        }

        [HttpPost]
        public ActionResult Student([FromForm] TestMOdel std)
        {
            // Getting Name
            string name = std.Name;
            // Getting Image
            var image = std.Image;
            // Saving Image on Server
            if (image != null) {
                
                var imageDataByteArray = Convert.FromBase64String(std.Image);

                var imageDataStream = new MemoryStream(imageDataByteArray);
                imageDataStream.Position = 0;

                //_customerImageService.Upload([...])
                
                var filePath = Path.Combine("wwwroot/docs", name);
                using (FileStream file = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write)) {
                    byte[] bytes = new byte[imageDataStream.Length];
                    imageDataStream.Read(bytes, 0, (int)imageDataStream.Length);
                    file.Write(bytes, 0, bytes.Length);
                    imageDataStream.Close();
                    var model = new TestMod
                    {
                        Name = name,
                        Image = name
                    };
                    appContext.TestMod.Add(model);
                    appContext.SaveChanges();
                }
            }

            return Ok(new { status = true, message = "Guardado"});
            
            
        }
    }
}