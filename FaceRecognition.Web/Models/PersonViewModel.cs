using System;
using System.ComponentModel.DataAnnotations;

namespace FaceRecognition.Web.Models
{
    public class PersonViewModel
    {
        public PersonViewModel() { }
        public PersonViewModel(Guid id)
        {
            Id = id;
        }

        public PersonViewModel(string gender, string age, Guid id/*, string sad, string hap, string ang, string surp*/)
        {
            Gender = gender;
            Age = age;
            //Surprise = surp;
            //Happiness = hap;
            //Anger = ang;
            //Sadness = sad;
            Id = id;
        }

        [StringLength(64)]
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [StringLength(64)]
        [Required(ErrorMessage = "Age is required")]
        public string Age { get; set; }


        //[StringLength(64)]
        //[Required(ErrorMessage = "Anger is required")]
        //public string Anger { get; set; }
        //[StringLength(64)]
        //[Required(ErrorMessage = "Happiness is required")]
        //public string Happiness { get; set; }
        //[StringLength(64)]
        //[Required(ErrorMessage = "Surprise is required")]
        //public string Surprise { get; set; }
        //[StringLength(64)]
        //[Required(ErrorMessage = "Sadness is required")]
        //public string Sadness { get; set; }

        [Required(ErrorMessage = "Url is required")]
        public string ImageUrl { get; set; }
        public Guid Id { get; set; }
        public double? Confidence { get; set; }
    }
}