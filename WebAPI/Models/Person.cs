using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace WebAPI.Models
{
    public class Person
    {
        [Key,MaxLength(7)] public int Id { get; set; }
        [Required,MaxLength(25)] public string FirstName { get; set; }
        [Required,MaxLength(25)] public string LastName { get; set; }
        [Required,Range(0,9000000)] public int MonthlySalary { get; set; }
        [Required,ValidHairColor] public string HairColor { get; set; }
        [Required,ValidEyeColor] public string EyeColor { get; set; }

        [Required, Range(1, 250)] public int Age { get; set; }
        [Required, Range(1, 250)] public float Weight { get; set; }
        [Required, Range(1, 250)] public int Height { get; set; }
        [Required,MaxLength(12)] public string Sex { get; set; }

        public void Update(Person toUpdate)
        {
            MonthlySalary = toUpdate.MonthlySalary;
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
                "white", "grey", "blue", "green"
            }.ToList();
            if (valid == null || valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green");
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

            return new ValidationResult("Valid hair colors are: Brown, Grey, Green, Blue, Amber, Hazel");
        }
    }
}