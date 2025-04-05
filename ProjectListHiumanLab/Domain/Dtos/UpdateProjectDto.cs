namespace ProjectListHiumanLab.Domain.Dtos;

public class UpdateProjectDto
{
    /// <summary>
    /// the identifier
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }
    /// <summary>
    /// Name
    /// </summary>
    /// <example>hiumanlab</example>
    public string Name { get; set; }
    /// <summary>
    /// Description
    /// </summary>
    /// <example>Software factory specializing in HR Tech, process automation, e-commerce, apps, geospatial systems, among others</example>
    public string Description { get; set; }
    /// <summary>
    /// status with possible values:
    /// - Pending
    /// - InProcess
    /// - Completed
    /// </summary>
    /// <example>Pending</example>
    public string Status { get; set; }
}
