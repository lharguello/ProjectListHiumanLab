using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectListHiumanLab.Domain.Dtos;
using ProjectListHiumanLab.Domain.Entities;
using ProjectListHiumanLab.Infrastructure.Data;

namespace ProjectListHiumanLab.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController(ProjectContext context, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Gets all projects.
    /// </summary>
    /// <returns>List of projects.</returns>
    /// <response code="200">Returns the list of projects.</response>
    [HttpGet]
    [ProducesResponseType(typeof(ProjectDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetProjects()
    {
        List<Project> projects = await context.Projects.ToListAsync();
        if (projects.Count == 0)
            return NotFound();
        return Ok(mapper.Map<List<ProjectDto>>(projects));
    }

    /// <summary>
    /// Gets a project by its ID.
    /// </summary>
    /// <param name="id">Project ID.</param>
    /// <returns>Project found.</returns>
    /// <response code="200">Returns the project found.</response>
    /// <response code="404">If the project doesn't exist.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProjectDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetProject(int id)
    {
        var project = await context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(mapper.Map<ProjectDto>(project));
    }

    /// <summary>
    /// Create a new project.
    /// </summary>
    /// <param name="request">Project data.</param>
    /// <returns>Project created.</returns>
    /// <response code="201">Returns the created project.</response>
    /// <response code="400">If the project data is invalid.</response>
    [HttpPost]
    [ProducesResponseType(typeof(ProjectDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PostProject(CreateProjectDto request)
    {
        var existProject = await context.Projects.Where(p => p.Name.ToLower() == request.Name.ToLower()).FirstOrDefaultAsync(); ;
        if (existProject != null)
        {
            return BadRequest("The project exist");
        }

        Project project = mapper.Map<Project>(request);
        project.CreatedAt = DateTime.Now;
        context.Projects.Add(project);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProject), new { id = project.Id }, mapper.Map<ProjectDto>(project));
    }

    /// <summary>
    /// Updates an existing project.
    /// </summary>
    /// <param name="id">The ID of the project to update.</param>
    /// <param name="projectDto">The updated project data.</param>
    /// <returns>The result of the operation.</returns>
    /// <response code="204">If the update was successful.</response>
    /// <response code="400">If the project data is invalid.</response>
    /// <response code="404">If the project does not exist.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutProject(int id, UpdateProjectDto projectDto)
    {
        if (id != projectDto.Id)
        {
            return BadRequest();
        }

        var project = await context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }

        project = mapper.Map(projectDto, project);
        project.ModifiedAt = DateTime.Now;
        context.Entry(project).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.Projects.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    /// <summary>
    /// Deletes a project by its ID.
    /// </summary>
    /// <param name="id">ID of the project to delete.</param>
    /// <returns>Result of the operation.</returns>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the project does not exist.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        context.Projects.Remove(project);
        await context.SaveChangesAsync();
        return NoContent();
    }
}