
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FaceRecognition.Web.Models;

namespace FaceRecognition.Web.Interfaces
{
    public interface IFaceAPIClient
    {
        Task<List<PersonViewModel>> RecognizeAsync(string imageUrl);
    }
}