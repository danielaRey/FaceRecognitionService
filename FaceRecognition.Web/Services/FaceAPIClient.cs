using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using FaceRecognition.Web.Interfaces;
//using Microsoft.ProjectOxford.Face;
using FaceRecognition.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace FaceRecognition.Web.Services
{
    public class FaceAPIClient : IFaceAPIClient
    {
        private readonly FaceClient faceServiceClient;
        private const string groupId = "demogroup";

        public FaceAPIClient(IConfiguration configuration)
        {
            faceServiceClient = new FaceClient(
                new ApiKeyServiceClientCredentials(configuration["FaceKey"])
            );
            faceServiceClient.Endpoint = configuration["FaceRoot"];
        }

        // public async Task CreatePersonAsync(string name, string description, byte[] imgdata)
        // {
        //     var response = await faceServiceClient.CreatePersonAsync(groupId, name, description);
        //     await AddFaceAsync(response.PersonId, imgdata);
        // }

        // public async Task AddFaceAsync(Guid personId, byte[] imgdata)
        // {
        //     await faceServiceClient.AddPersonFaceAsync(groupId, personId, new MemoryStream(imgdata));
        //     await faceServiceClient.TrainPersonGroupAsync(groupId);
        // }

        public async Task<List<PersonViewModel>> RecognizeAsync(string imageUrl)
        {
            var returnedAttributes = new List<FaceAttributeType>
            {
                FaceAttributeType.Age, FaceAttributeType.Gender, FaceAttributeType.Emotion
            };

            var faces = await faceServiceClient.Face.DetectWithUrlAsync(
              imageUrl,
              returnFaceAttributes: returnedAttributes
            );

            List<PersonViewModel> personAttributes = new List<PersonViewModel>();

            foreach (var face in faces)
            {
                personAttributes.Add(new PersonViewModel()
                {
                    Gender = face.FaceAttributes.Gender.ToString(),
                    Age = face.FaceAttributes.Age.ToString(),
                    //Anger = face.FaceAttributes.Emotion.Anger.ToString(),
                    //Sadness = face.FaceAttributes.Emotion.Sadness.ToString(),
                    //Happiness = face.FaceAttributes.Emotion.Happiness.ToString(),
                    //Surprise = face.FaceAttributes.Emotion.Surprise.ToString(),
                });
                Console.WriteLine($"Age: {face.FaceAttributes.Age}, Gender: {face.FaceAttributes.Gender}");
            }

            return personAttributes.ToList();
        }

        // public async Task<List<PersonViewModel>> GetAllAsync()
        // {
        //     return (await faceServiceClient.GetPersonsAsync(groupId)).Select(p => new PersonViewModel(p.Name, p.UserData, p.PersonId)).ToList();
        // }
    }
}