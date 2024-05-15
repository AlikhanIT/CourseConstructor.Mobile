﻿using CourseService.Gateway.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseService.Gateway.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("test-route")]
    public async Task<IActionResult> GetTestRoute()
    {
        var result = await _courseService.GetTestRoute();
        return Ok(result);
    }

    [HttpGet("countries")]
    public async Task<IActionResult> ListCountries()
    {
        var result = await _courseService.ListCountries();
        return Ok(result);
    }

    [HttpPost("clear-cache")]
    public async Task<IActionResult> ClearCache()
    {
        await _courseService.ClearCache();
        return NoContent();
    }

    [HttpGet("check-language")]
    public async Task<IActionResult> CheckLanguageSupport()
    {
        await _courseService.CheckLanguageSupport();
        return NoContent();
    }

    [HttpPost("create-course/{courseName}")]
    public async Task<IActionResult> CreateCourse(string courseName)
    {
        await _courseService.CreateCourse(courseName);
        return Ok();
    }

    // [HttpGet("all-courses")]
    // public async Task<IActionResult> ListAllCourses()
    // {
    //     var result = await _courseService.ListAllCourses();
    //     return Ok(result);
    // }

    [HttpPost("add-course/{userId}/{courseId}")]
    public async Task<IActionResult> AssignCourseToUser(Guid userId, Guid courseId)
    {
        await _courseService.AssignCourseToUser(userId, courseId);
        return Ok();
    }

    [HttpGet("user-courses/{userId}")]
    public async Task<IActionResult> GetUserCourses(Guid userId)
    {
        var result = await _courseService.GetUserCourses(userId);
        return Ok(result);
    }

    [HttpGet("course-details/{id}")]
    public async Task<IActionResult> GetCourseDetails(Guid id)
    {
        var result = await _courseService.GetCourseDetails(id);
        return Ok(result);
    }
}