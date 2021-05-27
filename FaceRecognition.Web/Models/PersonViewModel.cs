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

        public PersonViewModel(string name, string description, Guid id, string hap, string ang, string surp, string sad, string neu)
        {
            Name = name;
            Description = description;
            Id = id;

            Surprise = surp;
            Happiness = hap;
            Anger = ang;
            Sadness = sad;
            Neutral = neu;
        }

        [StringLength(64)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [StringLength(64)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Url is required")]
        public string ImageUrl { get; set; }
        public Guid Id { get; set; }
        public double? Confidence { get; set; }

        [StringLength(64)]
        [Required(ErrorMessage = "Anger is required")]
        public string Anger { get; set; }
        [StringLength(64)]
        [Required(ErrorMessage = "Happiness is required")]
        public string Happiness { get; set; }
        [StringLength(64)]
        [Required(ErrorMessage = "Surprise is required")]
        public string Surprise { get; set; }
        [StringLength(64)]
        [Required(ErrorMessage = "Sadness is required")]
        public string Sadness { get; set; }
        [StringLength(64)]
        [Required(ErrorMessage = "Neutral is required")]
        public string Neutral { get; set; }
    }
}