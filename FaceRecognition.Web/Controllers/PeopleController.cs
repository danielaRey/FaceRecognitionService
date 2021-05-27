using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FaceRecognition.Web.Interfaces;

namespace FaceRecognition.Web.Controllers
{
    public class PeopleController : BaseController
    {
        private readonly IFaceAPIClient faceClient;

        public PeopleController(IFaceAPIClient faceClient)
        {
            this.faceClient = faceClient;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Recognize()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detect(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return BadRequest("Url is required");
            }
            try
            {
                var imgdata = new WebClient().DownloadData(imageUrl);
                return Json(await faceClient.RecognizeAsync(imageUrl));
            }
            catch (WebException)
            {
                return BadRequest("Error accessing image, please try another");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error recognizing");
            }

            return UnprocessableEntity("Please try again later");
        }

    }
}