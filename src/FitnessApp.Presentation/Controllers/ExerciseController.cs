namespace FitnessApp.Presentation.Controllers;

using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class ExerciseController : Controller
{
    private readonly ISender sender;

    public ExerciseController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    [ActionName("Index")]
    public async Task<IActionResult> GetAll()
    {
        var getAllQuery = new GetAllQuery();

        var exercises = await this.sender.Send(getAllQuery);

        return base.View(model: exercises);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        var getByIdQuery = new GetByIdQuery(id);

        var exercise = await this.sender.Send(getByIdQuery);

        return base.View(model: exercise);
    }
}