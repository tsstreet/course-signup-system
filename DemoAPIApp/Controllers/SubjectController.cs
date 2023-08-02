﻿using AutoMapper;
using Azure.Core;
using DemoAPIApp.Data.Dto;
using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.SubjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        public SubjectController(ISubjectService subjectService, IMapper mapper) 
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult>GetSubjects()
        {
            var getSubject = await _subjectService.GetSubjects();

            var getSubjectDto = _mapper.Map<List<Subject>>(getSubject);

            return Ok(getSubjectDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {       
            var getSubject = await _subjectService.GetSubjectById(id);
            var getSubjectDto = _mapper.Map<Subject>(getSubject);

            return Ok(getSubjectDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject(SubjectDto subject)
        {
            var subjectMap = _mapper.Map<Subject>(subject);
            var subjectGet = await _subjectService.AddSubject(subjectMap);
            
            return Ok(subjectGet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, SubjectDto subject)
        {
            var subjectMap = _mapper.Map<Subject>(subject);
            var subjectUpdate = await _subjectService.UpdateSubject(id, subjectMap);

            return Ok(subjectMap);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var deleteSubject = await _subjectService.DeleteSubject(id);

            return Ok(deleteSubject);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var search = await _subjectService.Search(searchString);

            return Ok(search);
        }
    }
}
