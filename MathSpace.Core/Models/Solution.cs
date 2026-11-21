namespace MathSpace.Core.Models;

public class Solution
{
    public int Id { get; set; }

    public string Problem { get; set; } = string.Empty;

    public string Result { get; set; } = string.Empty;

    public string Steps { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
