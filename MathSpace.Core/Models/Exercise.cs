
using System.ComponentModel.DataAnnotations;

namespace MathSpace.Core.Models;

public class Exercise
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Question { get; set; } = string.Empty;

    public string Difficulty { get; set; } = "Easy";

    public int MathTopicId { get; set; }

    public MathTopic MathTopic { get; set; } = null!;
}
