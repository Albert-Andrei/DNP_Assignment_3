using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;

namespace Assigment_No3._0.Model
{
    public class Person
    {
        
        // [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required, MaxLength(20)] [NotNull] 
        // [JsonPropertyName("firstName")] 
        public string FirstName { get; set; }
        [NotNull] [Required, MaxLength(30)] 
        // [JsonPropertyName("lastName")] 
        public string LastName { get; set; }
        [ValidHairColor] [Required] 
        // [JsonPropertyName("hairColor")] 
        public string HairColor { get; set; }
        [NotNull] [ValidEyeColor] [Required] 
        // [JsonPropertyName("eyeColor")] 
        public string EyeColor { get; set; }
        [NotNull, Range(1, 125)][Required] 
        // [JsonPropertyName("age")] 
        public int Age { get; set; }
        [NotNull, Range(1, 250)][Required] 
        // [JsonPropertyName("weight")]
         public float Weight { get; set; }
        [NotNull, Range(30, 250)][Required] 
        // [JsonPropertyName("height")] 
        public int Height { get; set; }

        [NotNull]
        [Required, MaxLength(1, ErrorMessage = "Sex can be only M or F"),][ValidSex]
        // [JsonPropertyName("sex")]
        public string Sex { get; set; }

        public void Update(Person toUpdate)
        {
            Age = toUpdate.Age;
            Height = toUpdate.Height;
            HairColor = toUpdate.HairColor;
            Sex = toUpdate.Sex;
            Weight = toUpdate.Weight;
            EyeColor = toUpdate.EyeColor;
            FirstName = toUpdate.FirstName;
            LastName = toUpdate.LastName;
        }
    }

    public class ValidHairColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[]
            {
                "blond", "red", "brown", "black",
                "white", "grey", "blue", "green", "leverpostej"
            }.ToList();
            if (valid == null || valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                "Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
        }
    }

    public class ValidEyeColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[]
            {
                "brown", "grey", "green", "blue",
                "amber", "hazel"
            }.ToList();
            if (valid != null && valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Valid eye colors are: Brown, Grey, Green, Blue, Amber, Hazel");
        }
    }
    
    public class ValidSex : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[]
            {
                "m", "f", "M", "F"
            }.ToList();
            if (valid != null && valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Valid sex is: F or M ");
        }
    }
}