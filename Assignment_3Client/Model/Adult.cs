using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Assignment_3Client.Model {
    public class Adult : Person
    {
        [Required, MaxLength(20)] [NotNull] [JsonPropertyName("jobTitle")]public string JobTitle { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public void Update(Adult toUpdate)
        {
            JobTitle = toUpdate.JobTitle;
            base.Update(toUpdate);
        }
    }
}